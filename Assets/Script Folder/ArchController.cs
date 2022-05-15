using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArchController : MonoBehaviour
{
    GameObject _player;
    private ParticleSystem _particleSystem;
    public float _particleHigh=1.3f;

    [Header("パーティクルの拡がるスピード")]
    public float _expansionSpeed = 0.03f;

    [Header("パーティクル最大範囲")]
    public float _expansionlimit=1.3f;


    // Start is called before the first frame update
    void OnEnable()
    {
        _player = GameObject.Find("hip");
        var pPOs = _player.transform.position;
        transform.position = new Vector3(pPOs.x, _particleHigh, pPOs.z);

        _particleSystem = GetComponent<ParticleSystem>();
        var _shape = _particleSystem.shape;
        _shape.radius = 0;
    }

    // Update is called once per frame
    void Update()
    {
        var _shape = _particleSystem.shape;
        _shape.radius += _expansionSpeed*Time.deltaTime;
        if (_shape.radius > _expansionlimit)
        {
            _shape.radius = _expansionlimit;
        }
    }
}
