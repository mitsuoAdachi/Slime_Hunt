using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkillUp_DOT: MonoBehaviour
{

    float _activeTime = 2f;

    // Start is called before the first frame update
    void OnEnable()
    {

        var defaultPos = transform.localPosition;
        transform.localPosition = new Vector2(0.08f, -2f);
        transform.DOLocalMove(defaultPos, 0.5f);


        DOVirtual.DelayedCall(_activeTime, () =>
        {
            this.gameObject.SetActive(false);
        });

    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.rotation = Camera.main.transform.rotation;
    }
}
