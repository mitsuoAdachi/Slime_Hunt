using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApproachWall : MonoBehaviour
{
    Rigidbody _rigid;
    public float _wallBesideSpeed=1f;
    public float _wallVirticalSpeed=-1f;
    bool _moveStart = false;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        StartCoroutine(StartMoveWall());
    }

    // Update is called once per frame
    void Update()
    {
        if(_moveStart==true)
        {
            MoveWall();
        }
    }
    void MoveWall()
    {
        if (transform.position.z < 86.2f)
        {
            _rigid.velocity = new Vector3(0, 0, _wallBesideSpeed);
        }
        else
        {
            _rigid.velocity = new Vector3(_wallVirticalSpeed, 0, 0);
        }
    }
    private IEnumerator StartMoveWall()
    {
        yield return new WaitForSeconds(8);
        _moveStart = true;
    }
}
