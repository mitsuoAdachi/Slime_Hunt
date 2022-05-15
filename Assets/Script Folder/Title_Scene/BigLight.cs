using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigLight : MonoBehaviour
{
    GameObject _bigLight1;
    GameObject _bigLight2;

    // Start is called before the first frame update
    void Start()
    {
        _bigLight1 = transform.Find("PS_BigLight1").gameObject;
        _bigLight2 = transform.Find("PS_BigLight2").gameObject;

        StartCoroutine(BigLight_Active1());
        StartCoroutine(BigLight_Active2());

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator BigLight_Active1()
    {
        yield return new WaitForSeconds(6);
        _bigLight1.SetActive(true);
    }

    private IEnumerator BigLight_Active2()
    {
        yield return new WaitForSeconds(5);
        _bigLight2.SetActive(true);
    }
}
