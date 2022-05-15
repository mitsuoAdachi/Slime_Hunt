using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class TitleScene_SlimeMove1 : MonoBehaviour
{
    Vector3 _latestPos;
    public float _rotSpeed=10;
    public float _jumpHigh;
    public AudioSource _audioEscape;
    public GameObject _slimeP;

    bool _gameStart = false;

    // Start is called before the first frame update
    void OnEnable()
    {
        transform.LookAt(_slimeP.transform.position, Vector3.up);

        var slimePos = transform.position;
        var jumpPos = new Vector3(slimePos.x+0.5f, slimePos.y, slimePos.z-0.5f);
        this.transform.DOLocalJump(jumpPos, _jumpHigh, 1, 0.6f);

        DOVirtual.DelayedCall(1f, () =>
        {
            _gameStart = true;
            _audioEscape.Play();
        });


    }

    // Update is called once per frame
    void Update()
    {
        if (_gameStart)
        {
            this.transform.position += new Vector3(2f, 0, -1f);
        }
    }
}
