using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DOT_FadeIn_RawImage : MonoBehaviour
{
    RawImage _image;

    // Start is called before the first frame update
    void Start()
    {
        _image = GetComponent<RawImage>();
        _image.DOFade(1f, 2f);

        var defaultPosition = transform.localPosition;
        transform.localPosition = new Vector2(-167, -190f);
        transform.DOLocalMove(defaultPosition, 1f);
    }
}
