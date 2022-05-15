using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class Player_BossScene_Mode : MonoBehaviour
{
    Animator _animator;
    MobStatus _mobStatus;

    GameObject _playerAxis;
    GameObject _wepon;

    public GameObject _attackButton;
    public GameObject _attackStartButton;
    public GameObject _attackEndButton;

    public GameObject _normalAngleCamera;
    public GameObject _attackAngleCamera;
    //public CinemachineFreeLook _targetCamera;

    public AudioSource _attackStartSE;
    public AudioSource _attackEndSE;
    public AudioSource _NormalBGM;
    public AudioSource _FightBGM;

    void Start()
    {
        _animator = GetComponent<Animator>();
        _mobStatus = GetComponent<MobStatus>();
        _playerAxis = GameObject.Find("QueryChan2");
        _wepon = GameObject.Find("R_hand2").transform.Find("BattleAxe2").gameObject;
    }

    public void AttackModeStart()
    {
        _wepon.SetActive(true);
        _attackStartSE.Play();
        _NormalBGM.enabled = false;
        _FightBGM.enabled = true;
        _animator.SetBool("walk", true);
        _mobStatus._stateAttackMode = true;
        _normalAngleCamera.SetActive(!_normalAngleCamera.activeInHierarchy);
        _attackAngleCamera.SetActive(!_attackAngleCamera.activeInHierarchy);

        _attackButton.SetActive(true);
        _attackStartButton.SetActive(false);
        _attackEndButton.SetActive(true);

    }
    public void AttackModeEnd()
    {
        _animator.SetTrigger("attackEnd");
        _attackEndSE.Play();
        _NormalBGM.enabled = true;
        _FightBGM.enabled = false;
        _animator.SetBool("walk", false);
        _mobStatus._stateAttackMode = false;
        _normalAngleCamera.SetActive(!_normalAngleCamera.activeInHierarchy);
        _attackAngleCamera.SetActive(!_attackAngleCamera.activeInHierarchy);
        //_targetCamera.LookAt = _playerAxis.transform;

        _attackButton.SetActive(false);
        _attackStartButton.SetActive(true);
        _attackEndButton.SetActive(false);

        _wepon.SetActive(false);

    }
}
