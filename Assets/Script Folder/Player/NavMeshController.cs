using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{
    Animator _animator;
    MobStatus _mobStatus;
    NavMeshAgent _agent;

    Vector3 latestPos;
    Vector2 startPos, currentPos;

    public float _limitSpeedX = 130f;
    public float _limitSpeedZ = 120f;
    public float _runPower = 2000;
    public float _walkPower = 3000;
    public float _cameraSpeed = 1f;

    public AudioSource _footStepSE;

    float _rotSpeed=10f;
    int _moveFingerId;

    bool _gameStart = false;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _mobStatus = GetComponent<MobStatus>();
        _agent = GetComponent<NavMeshAgent>();

        StartCoroutine(GameStartCoroutine());
    }
    void Update()
    {
        //タッチ関数を使用した移動処理
        foreach (var touch in Input.touches)
        {
            if (touch.position.x < 800 && _mobStatus.stateFine )
            {
                if (touch.phase == TouchPhase.Began)
                {
                    _moveFingerId = touch.fingerId;
                    startPos = touch.position;
                }
                if (touch.phase == TouchPhase.Moved)
                {
                    currentPos = touch.position;
                }

                if (touch.fingerId == _moveFingerId)
                {
                    //Y軸への入力を画面奥へのベクトルに変換
                    var correctiveMotion = Quaternion.AngleAxis(Camera.main.transform.eulerAngles.y, Vector3.up);

                    Vector2 _move = currentPos - startPos;
                    float _moveX=Mathf.Clamp(_move.x,-_limitSpeedX, _limitSpeedX);
                    float _moveZ=Mathf.Clamp(_move.y,-_limitSpeedZ, _limitSpeedZ);
                    Vector3 _move3 = new Vector3(_moveX, 0, _moveZ);

                    _agent.isStopped = false;

                    if (_mobStatus._stateAttackMode)
                    {
                        _agent.Move(correctiveMotion * _move3 / _walkPower);
                    }
                    else
                    {
                        _agent.Move(correctiveMotion * _move3 / _runPower);
                        _animator.SetBool("run", true);
                    }

                }

                if (touch.phase == TouchPhase.Ended)
                {
                    _animator.SetBool("run", false);
                    OnFootStepStop();
                    _agent.isStopped = true;
                }
            }
        }

        if(_gameStart)
        {
            OnMoveLength();
        }

        //移動方向を向く
        Vector3 diff = transform.position - latestPos;
        latestPos = transform.position;
        if (diff.magnitude > 0.01f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(diff), Time.deltaTime * _rotSpeed);
        }
    }

    private void OnMoveLength()
    {
        //移動範囲制限
        float _slideCameraPosX = Camera.main.transform.position.x;
        float _slideCameraPosZ = Camera.main.transform.position.z;
        float _moveLengthX = Mathf.Clamp(transform.position.x, _slideCameraPosX-5, _slideCameraPosX-1);
        float _moveLengthZ = Mathf.Clamp(transform.position.z, _slideCameraPosZ - 2, _slideCameraPosZ + 3);
        transform.position = new Vector3(_moveLengthX, transform.position.y, _moveLengthZ);
        //Debug.Log("移動範囲"+_moveLengthZ);

    }

    private IEnumerator GameStartCoroutine()
    {
        yield return new WaitForSeconds(6);
        _gameStart = true;
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
