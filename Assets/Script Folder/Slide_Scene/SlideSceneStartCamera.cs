using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Cinemachine;

public class SlideSceneStartCamera : MonoBehaviour
{
    public CinemachineVirtualCamera _virtualCamera;
    CinemachineTrackedDolly _dolly;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Start_Camera());
        StartCoroutine(Menu_Camera());

        _dolly = _virtualCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    private IEnumerator Start_Camera()
    {
        yield return new WaitForSeconds(1f);
        _dolly.m_AutoDolly.m_Enabled = true;
    }

    private IEnumerator Menu_Camera()
    {
        yield return new WaitForSeconds(6);
        _virtualCamera.Priority -= 3;
        _dolly.m_AutoDolly.m_Enabled = false;
    }
}
