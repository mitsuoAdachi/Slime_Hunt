using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraController : MonoBehaviour
{
    //public FloatingJoystick inputRotate;
    //public float rotSpeed = 1f;
    //GameObject _player;
    //int _fingerId;
    //float angleX;
    //float angleY;
    //public float _maxAngle=10f;
    //public float _minAngle=-10f;

    Ray _ray;
    RaycastHit _hit;
    public LayerMask _layerMask;

    //public CinemachineVirtualCamera _targetCamera;
    public CinemachineFreeLook _targetCamera;

    void Start()
    {
    }

    void Update()
    {
        _ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(_ray, out _hit, 100f, _layerMask))
        {
            _targetCamera.LookAt = _hit.transform;
            //Debug.DrawRay(_ray.origin, _ray.direction * 10, Color.yellow);
            //Debug.Log("タップしたオブジェクト" + _hit.transform.position);
        }
        /*else
        {
            for (int i = 0; i < Input.touches.Length; i++)
            {
                Touch touch = Input.touches[i];
                if (touch.position.x > 1000)
                {
                    _fingerId = touch.fingerId;
                }

                if (touch.fingerId == _fingerId)
                {
                    //float currentAngleY = transform.eulerAngles.y;
                    //if (currentAngleY<_maxAngle && currentAngleY>_minAngle)
                    //if (transform.position.y > 0.5f && transform.position.y < 3)

                    angleX = inputRotate.Horizontal * rotSpeed;
                    angleY = inputRotate.Vertical * rotSpeed;
                    angleY = Mathf.Clamp(angleY, _minAngle, _maxAngle);

                    var _playerPos = _player.transform.position;
                    transform.RotateAround(_playerPos, Vector3.up, angleX);
                    transform.RotateAround(_playerPos, Vector3.left, angleY);
                    
                }
            }
        }*/
    }
}
