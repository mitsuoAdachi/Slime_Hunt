using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class StartCamera : MonoBehaviour
{
    public CinemachineVirtualCamera _virtualCamera;
    CinemachineTrackedDolly _dolly;
    GameObject _titleCanvas;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Start_Camera());
        StartCoroutine(Menu_Camera());
        StartCoroutine(Title_Active());

        _dolly = _virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
        _titleCanvas = transform.Find("Canvas_Title").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
    }
    private IEnumerator Start_Camera()
    {
        yield return new WaitForSeconds(0.2f);
        _dolly.m_AutoDolly.m_Enabled = true;
    }
    private IEnumerator Menu_Camera()
    {
        yield return new WaitForSeconds(8.5f);
        _virtualCamera.Priority -= 2;
        _dolly.m_AutoDolly.m_Enabled = false;
    }
    private IEnumerator Title_Active()
    {
        yield return new WaitForSeconds(10);
        _titleCanvas.SetActive(true);

    }

}
