using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SlideBossCamera : MonoBehaviour
{
    public CinemachineVirtualCamera _bossCamera;
    CinemachineTrackedDolly _dolly;

    // Start is called before the first frame update
    void Start()
    {
        _dolly = _bossCamera.GetCinemachineComponent<CinemachineTrackedDolly>();
    }

    // Update is called once per frame
    void Update()
    {
        if (_dolly.m_PathPosition > 0.96f)
        {

        }
    }
}
