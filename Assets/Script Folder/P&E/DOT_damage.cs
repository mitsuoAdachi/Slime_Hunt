using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DOT_damage : MonoBehaviour
{
    GameObject _parentObject;
    public float _jumpPower = 0.01f;
    public float _jumpHigh = 2f;
    public float _activeTime = 1.5f;
    private RectTransform _lookCamera;

    // Start is called before the first frame update
    void OnEnable()
    {
        _lookCamera = GetComponent<RectTransform>();

        _parentObject = transform.root.gameObject;
        var parentPos = _parentObject.transform.position;
        transform.position = parentPos;
        var cameraPos = new Vector3(Camera.main.transform.position.x, _jumpHigh, Camera.main.transform.position.z);
        var jumpPos = transform.position = Vector3.MoveTowards(parentPos,cameraPos,1f);
        transform.DOJump(jumpPos, _jumpPower, 2, 1f);
        //transform.parent = null;

        DOVirtual.DelayedCall(_activeTime, () =>
        {
            this.gameObject.SetActive(false);
        });
    }
    private void Update()
    {
        _lookCamera.LookAt(Camera.main.transform);
    }
}
