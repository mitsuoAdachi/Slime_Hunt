using UnityEngine;
using DG.Tweening;

public class DOT_ShakeScale : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        transform.DOShakeScale(1, 1.5f);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
