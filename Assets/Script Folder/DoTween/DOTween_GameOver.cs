using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DOTween_GameOver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        var transformCache = transform;
        var defaultPosition = transformCache.localPosition;
        transformCache.localPosition = new Vector2(-152, 400f);
        transformCache.DOLocalMove(defaultPosition, 2f)
          .SetEase(Ease.OutBounce);

        DOVirtual.DelayedCall(9, () =>
         {
             SceneManager.LoadScene("TitleScene");
         });
    }
}
