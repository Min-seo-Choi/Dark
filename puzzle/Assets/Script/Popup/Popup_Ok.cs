using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_Ok : MonoBehaviour
{
    [SerializeField]
    UILabel _subject;
    [SerializeField]
    UILabel _body;
    [SerializeField]
    UILabel _okBtnText;
    ButtonDelegate _okDelegate;


    public void SetUI(string subject, string body, ButtonDelegate okDel, string okBtnText = "OK")
    {
        _subject.text = subject;
        _body.text = body;
        _okDelegate = okDel;
        _okBtnText.text = okBtnText;
    }

    public void OnPressOK()
    {
        if (_okDelegate != null)
        {
            _okDelegate();
        }
        else
        {
            PopupManager.Instance.ClosePopup();
        }
    }

    public void OnPressX()
    {
        PopupManager.Instance.ClosePopup();
    }
}
