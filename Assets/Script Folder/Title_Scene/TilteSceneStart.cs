using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
using DG.Tweening;

public class TilteSceneStart : MonoBehaviour
{
    Animator _animator;
    CinemachineDollyCart _dollyP;
    CinemachineDollyCart _dollyC;
    TitleScene_SlimeMove1 _slimeMove1;
    GameObject _canvasSweat;
    GameObject _wepon;

    public Animator _wakayama;
    public Animator _yamagata;
    public AudioSource _audio;
    public AudioSource _audioEscape;
    public GameObject _slimeRed_P;
    public GameObject _slimeRed_C;

    private bool _gameStart1 = false;
    private bool _gameStart2 = false;
    private bool _gameStart3 = false;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _wepon = GameObject.Find("R_hand").transform.Find("Sword").gameObject;
        _canvasSweat = GameObject.Find("Slime_Red").transform.Find("Canvas_Sweat").gameObject;
        _dollyP = _slimeRed_P.GetComponent<CinemachineDollyCart>();
        _dollyC = _slimeRed_C.GetComponent<CinemachineDollyCart>();
        _slimeMove1 = _slimeRed_C.GetComponent<TitleScene_SlimeMove1>();
    }

    // Update is called once per frame
    void Update()
    {

        if (_gameStart1 == true)
        {
            _dollyP.enabled = false;
            _slimeRed_P.transform.position += new Vector3(0.02f, 0, -0.01f);
        }
        if (_gameStart2 == true)
        {
            _slimeRed_P.transform.position += new Vector3(2f, 0, -1f);
        }
        if (_gameStart3 == true)
        {
            _slimeMove1.enabled = true;
            _dollyC.enabled = false;
        }

    }
    public void GameStart()
    {
        _wepon.SetActive(true);
        _animator.SetTrigger("start");
        _wakayama.SetTrigger("start");
        _yamagata.SetTrigger("start");
        _audio.Play();

        StartCoroutine(SlimeEscapeCoroutine());
        StartCoroutine(GameStartCoroutine());

    }
    private IEnumerator SlimeEscapeCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        _canvasSweat.SetActive(true);
        _gameStart1 = true;

        yield return new WaitForSeconds(1.5f);
        _gameStart2 = true;
        _audioEscape.Play();

        yield return new WaitForSeconds(0.3f);
        _gameStart3 = true;

    }
    private IEnumerator GameStartCoroutine()
    {
        yield return new WaitForSeconds(6);
        SceneManager.LoadScene("SlideScene");
    }
}
