using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Dotween_Sweat : MonoBehaviour
{
    //private RectTransform _lookCamera;

    // Start is called before the first frame update
    void Start()
    {
        //_lookCamera = GetComponent<RectTransform>();

        var defaultPosition = transform.localPosition;
        transform.localPosition = new Vector2(0.08f, -0.18f);
        transform.DOLocalMove(defaultPosition, 0.5f).SetLoops(-1,LoopType.Restart);
    }

    /*private void Update()
    {
        _lookCamera.LookAt(Camera.main.transform);
    }*/
}
