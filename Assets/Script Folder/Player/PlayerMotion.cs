using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMotion : MonoBehaviour
{
    Rigidbody _rigid;
    Animator _animator;
    PlayerStatus _playerstatus;

    public GameObject _jumpButton;
    public GameObject _jumpAttackButton;
    public GameObject _attackButton;
    public GameObject _rollingButton;

    public AudioSource _rollingSE;
    public AudioSource _jumpVoiceSE;
    public AudioSource _jumpSE;
    public AudioSource _jumpAttackSE;

    public SphereCollider _collider;

    private void Start()
    {
        _rigid = GetComponent<Rigidbody>();
        _animator = GetComponent<Animator>();
        _playerstatus = GetComponent<PlayerStatus>();
    }

    public void PlayerJump()
    {
        _rigid.velocity = Vector3.zero;
        _animator.SetTrigger("jump");
        _jumpButton.SetActive(false);
        _attackButton.SetActive(false);
        _jumpSE.Play();
        _jumpVoiceSE.Play();
        StartCoroutine(JumpButtonCoroutine());
        StartCoroutine(JumpAttackCoroutine());
    }
    public void PlayerJumpAttack()
    {
        _rigid.velocity = Vector3.zero;
        _animator.SetTrigger("jumpAttack");
        _jumpButton.SetActive(false);
        _jumpAttackSE.Play();
    }

    public void Stamp()
    {
        _rigid.velocity = Vector3.zero;
        _animator.SetTrigger("jumpAttack");
        _jumpButton.SetActive(false);
        _jumpAttackSE.Play();
    }

    private IEnumerator JumpButtonCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        _jumpButton.SetActive(true);
        _attackButton.SetActive(true);

    }
    private IEnumerator JumpAttackCoroutine()
    {
        yield return new WaitForSeconds(0.2f);
        _jumpAttackButton.SetActive(true);
        yield return new WaitForSeconds(1f);
        _jumpAttackButton.SetActive(false);

    }

    public void PlayerRolling()
    {
        _collider.enabled = false;
        _animator.SetTrigger("rolling");
        _rollingSE.Play();
        _rigid.AddForce(transform.forward * 45f, ForceMode.Impulse);
        StartCoroutine(RollingCoroutine());
        _rollingButton.SetActive(false);

    }
    private IEnumerator RollingCoroutine()
    {
        yield return new WaitForSeconds(0.4f);
        _collider.enabled = true;
        yield return new WaitForSeconds(1.5f);
        _rollingButton.SetActive(true);

    }

}