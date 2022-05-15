using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DropItem : MonoBehaviour
{
    GameObject _parentObject;
    public float _jumpPower=2f;
    int _itemCount=0;

    // Start is called before the first frame update
    void Start()
    {
        _parentObject = transform.root.gameObject;
        var ptp = _parentObject.transform.position;

        var dropPosition = new Vector3(ptp.x-1f, ptp.y,ptp.z+4);
        transform.DOJump(dropPosition, _jumpPower, 2,0.7f);

        DOVirtual.DelayedCall(12, () =>
        {
            Destroy(this.gameObject);
        });
    }
    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.gameObject.CompareTag("Player"))
    //    {
    //        _itemCount += 1;
    //        Destroy(this.gameObject);
    //    }          
    //}
}
