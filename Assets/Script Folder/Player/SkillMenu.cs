using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;


public class SkillMenu : MonoBehaviour
{
    public Image _skillMenu;
    public GameObject _skillOnButton, _skillOffButton;

    private void Start()
    {
        Debug.Log("localPosition" + transform.localPosition);
    }
    public void OnSkillMenu()
    {
        //_onSkill = true;
        this.gameObject.SetActive(true);

        _skillMenu.DOFade(1f, 2f);

        var _defaultPos = transform.localPosition = new Vector3(-133f, -438f);
        //Debug.Log(transform.localPosition);
        transform.localPosition = new Vector2(-1785f, -438f);
        transform.DOLocalMove(_defaultPos, 2f);

        _skillOnButton.SetActive(!_skillOnButton.activeInHierarchy);
        _skillOffButton.SetActive(!_skillOnButton.activeInHierarchy);


    }
    public void OffSkillMenu()
    {
        _skillMenu.DOFade(0f, 2f);

        var _defaultPos = transform.localPosition = new Vector3(-1785, -438f);
        //Debug.Log(transform.localPosition);
        transform.localPosition = new Vector2(-133f, -438f);
        transform.DOLocalMove(_defaultPos, 2f);

        DOVirtual.DelayedCall(1.5f, () =>
        {
            this.gameObject.SetActive(false);

            _skillOnButton.SetActive(!_skillOnButton.activeInHierarchy);
            _skillOffButton.SetActive(!_skillOnButton.activeInHierarchy);
        });
    }
}
