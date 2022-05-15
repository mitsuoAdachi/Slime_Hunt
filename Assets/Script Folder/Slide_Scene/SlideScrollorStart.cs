using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class SlideScrollorStart : MonoBehaviour
{
    public GameObject _virticalCamera;
    public CinemachineVirtualCamera _slideCamera;
    CinemachineTrackedDolly _slideDolly;

    public float _cameraSpeed = 0.01f;
    bool _moveStart = false;

    Spawner _spawner;

    // Start is called before the first frame update
    void Start()
    {
        _spawner = GameObject.Find("Context").GetComponent<Spawner>();
        _slideDolly = _slideCamera.GetCinemachineComponent<CinemachineTrackedDolly>();

        StartCoroutine(DollyStartCoroutine());

    }

    // Update is called once per frame
    void Update()
    {
        if(_moveStart==true)
        {
            DollyStart();
            _spawner.enabled=true;
        }
    }
    void DollyStart()
    {
        _slideDolly.m_PathPosition += _cameraSpeed * Time.deltaTime;

        if (_slideDolly.m_PathPosition > 0.96f)
        {
            _virticalCamera.SetActive(true);
            this.gameObject.SetActive(false);
        }

    }
    private IEnumerator DollyStartCoroutine()
    {
        yield return new WaitForSeconds(8);
        _moveStart = true;
    }
}
