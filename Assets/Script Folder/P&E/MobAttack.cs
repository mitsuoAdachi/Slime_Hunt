using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobAttack : MonoBehaviour
{
    Animator _animator;

    private WeponSlash _weponSlash;
    private MobStatus _mobStatus;
    public ParticleSystem _particle;  
    public AudioSource _attackSE;

    // Start is called before the first frame update
    private void Awake()
    {
        _weponSlash = GetComponent<WeponSlash>();

    }
    void Start()
    {
        _mobStatus = GetComponentInParent<MobStatus>();
        _animator = GetComponentInParent<Animator>();
    }

    private void OnTriggerStay(Collider collider)
    {
        if (collider.CompareTag("Player") && collider.transform.root.gameObject.GetComponent<MobStatus>().stateFine && _mobStatus.stateAttack)
        {
            _animator.SetTrigger("attack");
            _mobStatus.stateAttack = false;
            _attackSE.Play();
        }
    }

    public void PlayerAttack()
    {
        if (_mobStatus.stateAttack)
        {
            _animator.SetTrigger("attack");
            _attackSE.Play();
            _particle.Play();
            //_particle.transform.parent = null;
            //_particle.SetActive(true);
            //_weponSlash.enabled = true;
            
            StartCoroutine(OnParticle());

        }
    }
    private IEnumerator OnParticle()
    {
        yield return new WaitForSeconds(1);
        //_particle.transform.parent = GameObject.Find("QueryChan").transform;
        //_particle.SetActive(false);
        //_weponSlash.enabled = false;


    }
}