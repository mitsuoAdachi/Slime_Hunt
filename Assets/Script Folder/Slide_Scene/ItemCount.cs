using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemCount : MonoBehaviour
{
    public PlayerStatus _playerStatus;
    [Header("アイテム取得数")]
    public TextMeshProUGUI _appleText;
    public TextMeshProUGUI _bananaText;

    void Update()
    {
        //Debug.Log(_playerStatus._appleCount);
        _appleText.text = _playerStatus._appleCount.ToString();
        //Debug.Log(_playerStatus._bananaCount);
        _bananaText.text = _playerStatus._bananaCount.ToString();

    }
    //public void ItemGetCount(float _appleCount,float _bananaCount)
    //{
    //    _appleText.text = _appleCount.ToString();
    //    _bananaText.text = _bananaCount.ToString();
    //}
}
