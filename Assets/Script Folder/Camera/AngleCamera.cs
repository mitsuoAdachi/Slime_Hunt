using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AngleCamera : MonoBehaviour
{
    //private RectTransform _lookCamera;

    // Start is called before the first frame update
    //void Start()
    //{
    //    _lookCamera = GetComponent<RectTransform>();
    //}

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }

    //void LateUpdate()
    //{
    //    //_lookCamera.LookAt(Camera.main.transform);

    //}
}
