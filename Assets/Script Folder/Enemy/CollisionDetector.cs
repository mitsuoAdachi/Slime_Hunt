using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CollisionDetector : MonoBehaviour
{
    GameObject _parent;
    EnemyMove _enemyMove;


    // Start is called before the first frame update
    void Start()
    {
        _parent = transform.parent.gameObject;
        _enemyMove = _parent.GetComponent<EnemyMove>();
    }

    // 子オブジェクトの衝突を親オブジェクトで検知
    public void OnTriggerStay(Collider _collider)
    {
        _enemyMove.OnChildTriggerStay(_collider);
    }
}
