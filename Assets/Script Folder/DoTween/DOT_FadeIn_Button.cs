using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DOT_FadeIn_Button : MonoBehaviour
{
    TextMeshProUGUI _text;
    //RectTransform _rectTransform;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.DOFade(1f, 3f);

        //_rectTransform = gameObject.GetComponent<RectTransform>();

        /*var defaultPosition = transform.localPosition;
        transform.localPosition = new Vector2(200, -250f);
        transform.DOLocalMove(defaultPosition, 1f);*/
    }
}
