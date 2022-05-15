using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using TMPro;

public class DOT_FadeIn_TextMeshPro : MonoBehaviour
{
    TextMeshProUGUI _text;

    // Start is called before the first frame update
    void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _text.DOFade(1f, 2f);

        var defaultPosition = transform.localPosition;
        transform.localPosition = new Vector2(0, -80f);
        transform.DOLocalMove(defaultPosition, 1f);
    }
}
