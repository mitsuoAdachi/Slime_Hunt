using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideSceneStartCanvas : MonoBehaviour
{
    GameObject _canvasStart1;
    GameObject _canvasStart2;
    GameObject _canvasButton;

    public AudioSource _audioStart;
    public AudioSource _audioStage1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Stage1Text());
        StartCoroutine(StartText());
        _canvasStart1 = transform.Find("Stage1_Panel").gameObject;
        _canvasStart2 = transform.Find("Start_Text").gameObject;
        _canvasButton = transform.Find("Canvas_Button").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private IEnumerator Stage1Text()
    {
        yield return new WaitForSeconds(1f);
        _canvasStart1.SetActive(true);
        _audioStage1.Play();

    }
    private IEnumerator StartText()
    {
        yield return new WaitForSeconds(7f);
        _canvasStart1.SetActive(false);
        _canvasStart2.SetActive(true);
        _audioStart.Play();
        _canvasButton.SetActive(true);
        yield return new WaitForSeconds(3);
        _canvasStart2.SetActive(false);

    }

}
