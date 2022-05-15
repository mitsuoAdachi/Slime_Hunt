using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class MobStatus : MonoBehaviour
{
    Animator _animator;

    public bool stateFine = true;
    public bool stateAttack = true;
    public bool _stateAttackMode = false;

    public float lifeMax = 10;
    public float life = 10;

    public AudioSource _weponSE;
    public AudioSource _damageSE;

    public Collider _damageCollider;
    public ParticleSystem _damageEffect;
    public GameObject _damagePointUI;
    public int _damagePoint;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        life = lifeMax;
        _animator = GetComponent<Animator>();
    }

    protected virtual void Update()
    {
        if (life < 1 && stateFine)
        {
            OnDie();
            stateFine = false;  
        }
    }

    protected virtual void OnDie()
    {
        //Debug.Log("死亡確認");
        _animator.SetTrigger("die");
    }

    public void Damage(int damage)
    {
        if (stateFine == true)
        {
            life -= damage;
            _damagePoint = damage;
            _damagePointUI.SetActive(true);
            _damageSE.Play();
            _damageEffect.Play();
        }        
    }

    public void DamageStart()
    {
        _damageCollider.enabled = true;
        //_AttackSE.pitch = Random.Range(0.7f, 1.3f);
        _weponSE.Play();
    }

    public void EnemyDamageFinish()
    {
        stateAttack = false;
        _damageCollider.enabled = false;
        StartCoroutine(CoolDown(3.5f));
    }

    public void PlayerDamageFinish()
    {
        stateAttack = false;
        _damageCollider.enabled = false;
        StartCoroutine(CoolDown(1f));
    }

    private IEnumerator CoolDown(float coolDownTime)
    {
        yield return new WaitForSeconds(coolDownTime);
        if (stateFine==true)
        stateAttack = true;
    }
}
