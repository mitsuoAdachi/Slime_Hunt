using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController_Main : MonoBehaviour
{
    Animator _animator;
    MobStatus _mobStatus;
    NavMeshAgent _agent;

    Vector3 latestPos;
    Vector2 startPos, currentPos;

    public float _limitSpeedX = 130f;
    public float _limitSpeedY = 120f;
    public float _runPower = 2000;
    public float _walkPower = 3000;
    public float _cameraSpeed = 1f;

    public AudioSource _footStepSE;

    float _rotSpeed = 10f;
    int _moveFingerId;

    bool _gameStart = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _mobStatus = GetComponent<MobStatus>();
        _agent = GetComponent<NavMeshAgent>();

    }
    void Update()
    {
        //タッチ関数を使用した移動処理
        foreach (var touch in Input.touches)
        {
            if (touch.position.x < 800 && _mobStatus.stateFine)
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
                    var correctiveMotion = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);
                    Vector2 _move = currentPos - startPos;
                    float _moveX = Mathf.Clamp(_move.x, -_limitSpeedX, _limitSpeedX);
                    float _moveY = Mathf.Clamp(_move.y, -_limitSpeedY, _limitSpeedY);
                    //Debug.Log("_move distance" + _move);
                    Vector3 _move3 = new Vector3(_moveX, 0, _moveY);

                    _agent.isStopped = false;

                    if (_mobStatus._stateAttackMode)
                    {
                        //_rigid.AddForce(correctiveMotion * _move3 / _walkPower, ForceMode.Force);
                        _agent.Move(correctiveMotion * _move3 / _walkPower);
                    }
                    else
                    {
                        //if (_rigid.velocity.magnitude < _limitSpeed)
                        {
                            //_rigid.AddForce(correctiveMotion * _move3 / _runPower, ForceMode.VelocityChange);
                            _agent.Move(correctiveMotion * _move3 / _runPower);
                            _animator.SetBool("run", true);
                            //Debug.Log(("移動速度") + _rigid.velocity.magnitude);
                        }
                    }

                }

                if (touch.phase == TouchPhase.Ended)
                {
                    _animator.SetBool("run", false);
                    OnFootStepStop();
                    //_rigid.velocity = Vector3.zero;
                    _agent.isStopped = true;
                }
            }
        }

        //移動方向を向く
        Vector3 diff = transform.position - latestPos;
        latestPos = transform.position;
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(diff), Time.deltaTime * _rotSpeed);
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