using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using Cinemachine;
using DG.Tweening;

public class PlayerStatus : MobStatus
{
    Animator _animator;
    NavMeshAgent _agent;
    GameObject _gameOverUI;
    GameObject _skillUpUI;
    //ItemCount _itemCount;

    [Header("スキル関連")]
    public ParticleSystem _bafStartPS;
    public GameObject _baf1,_baf2,_baf1Button, _baf2Button,_stampButton;

    [Header("音響")]
    public AudioSource _ItemGetSE;
    public AudioSource _bafVoiceSE, _bafButtonSE, _baf2SE, _baf2VoiceSE;

    public GameObject _canvasButtonUI;
    public SphereCollider _hipCollider;

    public float _invincibleTime = 1f;
    public float _appleCount, _bananaCount;

    float _currentLife, _startLife;


    bool _baf2Switch = false;
    bool OnNoise = false;

    public CinemachineBrain _cmBrain;
    //private ICinemachineCamera _cmICam;
    //CinemachineImpulseListener _noiseProfile;

    protected override void Start()
    {
        base.Start();
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
        //_itemCount = GetComponent<ItemCount>();
        _gameOverUI = transform.Find("Canvas_GameOver").gameObject;
        _skillUpUI = transform.Find("Canvas_State/SkillUp").gameObject;
        _startLife = life;

    }

    protected override void Update()
    {
        base.Update();

        _currentLife = life;
        if(_startLife!=_currentLife)
        {
            Debug.Log("被ダメージ");
            _hipCollider.enabled = false;
            _animator.SetTrigger("damage");

            StartCoroutine(DamageCoroutine());
            _startLife = _currentLife;
        }


    }
    public void LateUpdate()
    {
        if (OnNoise == true)
        {
            var _noise = GetComponent<Cinemachine.CinemachineImpulseSource>();
            _noise.GenerateImpulse();
            //_cmICam = _cmBrain.ActiveVirtualCamera;
            //GameObject _noiseCam = _cmICam.VirtualCameraGameObject;
            //Debug.Log("NoiseCamera" + _noiseCam);
            //_noiseProfile = _noiseCam.GetComponent<CinemachineImpulseListener>();
            //_noiseProfile.enabled = true;
        }
    }
    private IEnumerator DamageCoroutine()
    {
        yield return new WaitForSeconds(_invincibleTime);
        _hipCollider.enabled = true;

    }

    protected override void OnDie()
    {
        base.OnDie();

        _agent.isStopped = true;
        _canvasButtonUI.SetActive(false);
        StartCoroutine(GameOverCoroutine());
    }
    private IEnumerator GameOverCoroutine()
    {
        yield return new WaitForSeconds(5);
        _gameOverUI.SetActive(true);  
    }
    
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Apple"))
        {
            _ItemGetSE.Play();
            _appleCount += 1;
            //Debug.Log(_appleCount);
           // _itemCount.ItemGetCount(_appleCount, 0);
            Destroy(collision.gameObject);

        }
        if (collision.gameObject.CompareTag("Banana"))
        {
            _ItemGetSE.Play();
            _bananaCount += 1;
            //Debug.Log(_bananaCount);
            //_itemCount.ItemGetCount(0, _bananaCount);
            Destroy(collision.gameObject);
        }

    }

    public void Baf1()
    {
        _baf1.SetActive(true);
        _baf1Button.GetComponent<Button>().interactable = false;
        _bafButtonSE.Play();
        _bafStartPS.Play();
        _skillUpUI.SetActive(true);
        StartCoroutine("Baf1OnCoroutine");
    }
    private IEnumerator Baf1OnCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        _bafVoiceSE.Play();
        _skillUpUI.SetActive(false);

    }

    public void Baf2()
    {
        _baf2Switch = true;
        _baf2Button.GetComponent<Button>().interactable = false;
        _bafButtonSE.Play();
        _bafStartPS.Play();
        _skillUpUI.SetActive(true);
        _stampButton.SetActive(true);
        StartCoroutine("Baf2OnCoroutine");
    }
    private IEnumerator Baf2OnCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        _bafVoiceSE.Play();
        _skillUpUI.SetActive(false);
    }

    public void OnStamp()
    {
        _animator.SetTrigger("stamp");
        _agent.isStopped = true;
    }
    public void OnStampParticle()
    {
        _baf2.SetActive(true);
        _baf2SE.Play();
        OnNoise = true;
        StartCoroutine(Baf2SwithCoroutine());
    }
    private IEnumerator Baf2SwithCoroutine()
    {
        yield return new WaitForSeconds(0.5f);
        OnNoise = false;
       // _noiseProfile.enabled = false;

        yield return new WaitForSeconds(1f);
        _baf2.SetActive(false);
        _agent.isStopped = false;


    }

    public void OnBaf2Voice()
    {
        _baf2VoiceSE.Play();
    }

}
