using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private NavMeshAgent _agent;
    private RaycastHit[] _raycastHit = new RaycastHit[10];
    GameObject _playerMove;
    Animator _animator;
    MobStatus _mobStatus;

    public LayerMask _layerMask;
    public GameObject _batBallAttack;

    // Start is called before the first frame update
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _playerMove = GameObject.Find("QueryChan");
        _animator = GetComponent<Animator>();
        _mobStatus = GetComponent<MobStatus>();
    }

    // Update is called once per frame
    public void OnChildTriggerStay(Collider _collider)
    {
        var _distance = _collider.transform.position - transform.position;
        var _hitCount = Physics.RaycastNonAlloc(transform.position, _distance.normalized, _raycastHit, _distance.magnitude, _layerMask);
        Debug.Log("hitCount" + _hitCount);

        if(_hitCount == 1||_hitCount == 0 && _collider.GetComponent<MobStatus>().stateFine && _mobStatus.stateFine)
        {
            Debug.Log("”発見”");
            _agent.isStopped =false;
            _agent.destination = _playerMove.transform.position;
            _animator.SetFloat("move", _agent.velocity.magnitude);
            _batBallAttack.SetActive(true);

        }
        else
        {
            _agent.isStopped = true;
        }
    }
}
