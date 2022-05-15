//DG.Tweening.DoTween.SetTweensCapacity(tweenersCapacity: 800, sequencesCapacity: 200);
using DG.Tweening;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class DamagePoint : MonoBehaviour
{
    private RectTransform _lookCamera;

    MobStatus _mobStatus;
    TextMeshProUGUI _damageText;

    // Start is called before the first frame update
    void Awake()
    {
        _lookCamera = GetComponent<RectTransform>();
        _mobStatus = GetComponentInParent<MobStatus>();
        _damageText = GetComponent<TextMeshProUGUI>();
    }

    void OnEnable() {
        var transformCache = transform;
        var defaultPosition = transformCache.localPosition;

        transformCache.localPosition = new Vector2(0, 0.5f);
        transformCache.DOLocalMove(defaultPosition, 1f)
          .SetEase(Ease.OutBounce);

        DOVirtual.DelayedCall(1.5f, () =>
        {
            this.gameObject.SetActive(false);
        });

        _damageText.text = _mobStatus._damagePoint.ToString("D1");

    }

    // Update is called once per frame
    void Update()
    {
        _lookCamera.LookAt(Camera.main.transform);
       //Debug.Log("ダメージ"+_mobStatus._damagePoint);
    }
}
