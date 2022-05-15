using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_BossStrart_Motion : MonoBehaviour
{
    Animator _animator;
    public AudioSource _jumpVoiceSE;
    public AudioSource _weponSE;

    // Start is called before the first frame update
    void OnEnable()
    {
        _animator.SetTrigger("entry");
    }

    public void OnJumpVoice()
    {
        _jumpVoiceSE.Play();
    }
    public void OnWeponSE()
    {
        _weponSE.Play();
    }

}
