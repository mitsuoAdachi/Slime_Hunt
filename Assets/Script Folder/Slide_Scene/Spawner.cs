using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class Spawner : MonoBehaviour
{
    GameObject _player;
    public PlayerStatus _playerStatus;
    public GameObject _enemyPrefab5;
    public GameObject _enemyPrefab10;
    public float _respon5 = 5f;
    public float _respon10 = 10f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnLoop5());
        StartCoroutine(SpawnLoop10());
    }

    private void Update()
    {
        if (_playerStatus.transform.position.x < -55)
        {
            this.gameObject.SetActive(false);
        }
    }

    private IEnumerator SpawnLoop5()
    {
        while(true)
        {
            if (_playerStatus.transform.position.z < 88)
            {
                Respon(0, 10, _enemyPrefab5);
            }
            else
            {
                Respon(-10, 0, _enemyPrefab5);
            }
            yield return new WaitForSeconds(_respon5);
            if (!_playerStatus.stateFine)
                break;

        }
    }
    private IEnumerator SpawnLoop10()
    {
        while (true)
        {
            if (_playerStatus.transform.position.z < 88)
            {
                Respon(0, 10, _enemyPrefab10);
            }
            else
            {
                Respon(-10, 0, _enemyPrefab10);
            }
            yield return new WaitForSeconds(_respon10);
            if (!_playerStatus.stateFine)
                break;
        }
    }

    private void Respon(float distanceX,float distanceZ,GameObject obj)
    {
        var _spawnradius = new Vector3(distanceX, 0, distanceZ);
        var _spawnPositionFromPlayer = Quaternion.Euler(0, Random.Range(-30, 30), 0) * _spawnradius;
        var _spawnPosition = _playerStatus.transform.position + _spawnPositionFromPlayer;

        NavMeshHit navMeshHit;
        if (NavMesh.SamplePosition(_spawnPosition, out navMeshHit, 10, NavMesh.AllAreas))
        {
            Instantiate(obj, navMeshHit.position, Quaternion.Euler(0, 180, 0));
        }
    }
}
