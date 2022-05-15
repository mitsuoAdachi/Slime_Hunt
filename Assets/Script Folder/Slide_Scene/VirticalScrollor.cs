using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;

public class VirticalScrollor : MonoBehaviour
{
    GameObject _playerShader, _playerName;
    public float _wallSpeed = 0.04f;
    public GameObject _PlayerEntry;
    public ParticleSystem _sceneChangeParticle;
    public AudioSource _bossBGM, _normalBGM, _sceneChangeBGM;
    public CinemachineVirtualCamera _virticalCamera, _bossCamera1;
    CinemachineTrackedDolly _slideDolly;

    // Start is called before the first frame update
    void Start()
    {
        _playerShader = GameObject.Find("SD_QUERY");
        _playerName = GameObject.Find("Canvas_State");
        _slideDolly = _virticalCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        _slideDolly.m_PathPosition += _wallSpeed * Time.deltaTime;

        if(_slideDolly.m_PathPosition > 80f)
        {
            _normalBGM.volume -= 0.005f;
        }

        if(_slideDolly.m_PathPosition > 92f)
        {
            StartCoroutine(BossCameraCoroutine());

            _bossCamera1.Priority += 10;
            _normalBGM.Stop();
            _bossBGM.Play();

            this.enabled = false;
        }
    }
    private IEnumerator BossCameraCoroutine()
    {
        yield return new WaitForSeconds(1.5f);
        _playerShader.SetActive(false);
        _playerName.SetActive(false);

        yield return new WaitForSeconds(2f);
        _PlayerEntry.SetActive(true);

        yield return new WaitForSeconds(3);
        _sceneChangeBGM.Play();
        _sceneChangeParticle.Play();

        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("MainScene");
    }
}
