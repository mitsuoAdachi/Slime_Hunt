using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TitleScene_SlimeMove : MonoBehaviour
{
    Vector3 _latestPos;
    public float _rotSpeed=10;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 diff = transform.position - _latestPos;
        _latestPos = transform.position;
        if (diff.magnitude > 0.001f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(diff), Time.deltaTime * _rotSpeed);
        }

    }
}
