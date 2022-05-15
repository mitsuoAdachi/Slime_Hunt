using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatAttackBall : MonoBehaviour
{
    private GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("QueryChan");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var targetMob = _player.transform.root.gameObject.GetComponent<MobStatus>();
            //if (null == targetMob) return;
            targetMob.Damage(Random.Range(1, 3));
        }
    }
}
