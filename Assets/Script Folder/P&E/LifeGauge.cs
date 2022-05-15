using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LifeGauge : MonoBehaviour
{
    MobStatus _mobStatus;
    Image _fillImage;
    public float _corrective;
    private RectTransform _lookCamera;

    // Start is called before the first frame update
    void Start()
    {
        _mobStatus = GetComponentInParent<MobStatus>();
        _fillImage = GetComponentInChildren<Image>();
        _lookCamera = GetComponent<RectTransform>();
        
    }

    // Update is called once per frame
    void Update()
    {
        _fillImage.fillAmount = _mobStatus.life / _mobStatus.lifeMax;

        //Vector3 _parentPosition = transform.parent.position;
        //transform.position = new Vector3(_parentPosition.x, _parentPosition.y + _corrective, _parentPosition.z);

        _lookCamera.LookAt(Camera.main.transform);
    }
}
