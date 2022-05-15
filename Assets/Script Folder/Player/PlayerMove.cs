using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    Rigidbody _rigid;
    Animator _animator;
    MobStatus _mobStatus;
    GameObject _mainCamera;

    Vector3 latestPos;
    Vector2 startPos, currentPos;

    public float _runPower=50;
    public float _walkPower=90;
    public AudioSource _footStepSE;

    int _moveFingerId;
    float _rotSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _mainCamera = GameObject.Find("Main Camera");
        _animator = GetComponent<Animator>();
        _mobStatus = GetComponent<MobStatus>();

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 diff = transform.position - latestPos;
        latestPos = transform.position;
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(diff), Time.deltaTime * _rotSpeed);
        }

        /*if (Mathf.Approximately(_rigid.velocity.magnitude, -1f) == false)
        {
            _footStepSE.Play();
        }

        /*if (Input.touchCount > 0)
        {_mobStatus._stateAttackMode==false && 
            Touch touch = Input.GetTouch(0);*/

        foreach (var touch in Input.touches)
        {
            if (touch.position.x < 700 && _mobStatus.stateFine)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _moveFingerId = touch.fingerId;
                    //_rigid.isKinematic = false;
                    startPos = touch.position;
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    currentPos = touch.position;
                }

                if (touch.fingerId == _moveFingerId)
                {
                    var correctiveMotion = Quaternion.AngleAxis(_mainCamera.transform.eulerAngles.y, Vector3.up);
                    Vector2 _move = currentPos - startPos;
                    Vector3 _move3 = new Vector3(_move.x, 0, _move.y);

                    if (_mobStatus._stateAttackMode)
                    {
                        _rigid.AddForce(correctiveMotion * _move3 / _walkPower, ForceMode.Force);
                    }
                    else
                    {
                        _rigid.AddForce(correctiveMotion * _move3 / _runPower, ForceMode.VelocityChange);
                        _animator.SetBool("run", true);
                        Debug.Log(("移動速度") + _rigid.velocity.magnitude);
                    }
                }
            }
            if (touch.phase == TouchPhase.Ended)
            {
                _animator.SetBool("run", false);
                _rigid.velocity = Vector3.zero;
                _footStepSE.Stop();

            }

        }
    }

    void OnFootStepStart()
    {
        _footStepSE.Play();
    }
    void OnFootStepStop()
    {
        _footStepSE.Stop();
    }

}
