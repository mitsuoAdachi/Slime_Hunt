using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatus : MobStatus
{
    public ParticleSystem _particleSystem2;
    public ParticleSystem _particleSystem3;
    public AudioSource _audioSource;

    //Animator _animator;

    GameObject _dropItem1;
    GameObject _dropItem2;

    private int _probability;

    // Start is called before the first frame update
    protected override void Start()
    {
        base.Start();
        _dropItem1 = transform.Find("Apple").gameObject;
        _dropItem2 = transform.Find("banana").gameObject;

        //_animator = GetComponent<Animator>();

        StartCoroutine(LifetimeCoroutine());
    }
    private IEnumerator LifetimeCoroutine()
    {
        yield return new WaitForSeconds(15);
        Destroy(this.gameObject);
    }

    protected override void Update()
    {
        base.Update();
    }


    protected override void OnDie()
    {
        base.OnDie();

        //_animator.ResetTrigger("attack");
        //_animator.ResetTrigger("damage");

        _probability = Random.Range(1, 99);
        if (_probability > 50)
        {
            _dropItem1.SetActive(true);
            _dropItem1.transform.parent = null;
        }
        else
        {
            _dropItem2.SetActive(true);
            _dropItem2.transform.parent = null;

        }

        _audioSource.Play();
        _particleSystem2.Play();
        _particleSystem3.Play();

        StartCoroutine(DestroyCoroutine());

    }
    private IEnumerator DestroyCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        Destroy(this.gameObject);
    }
}
