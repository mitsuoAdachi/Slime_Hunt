using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotAxis : MonoBehaviour
{
    GameObject _player;

    // Start is called before the first frame update
    void Start()
    {
        _player = GameObject.Find("QueryChan"); 
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 _playerPos = _player.transform.position;
        transform.position = new Vector3(_playerPos.x, _playerPos.y+0.5f, _playerPos.z);
    }
}
