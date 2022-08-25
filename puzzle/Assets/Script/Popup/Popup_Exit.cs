using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Popup_Exit : MonoBehaviour
{
    [SerializeField]
    UILabel _subject;
    [SerializeField]
    UILabel _cancelBtnText;
    [SerializeField]
    UILabel _goTitleBtnText;
    ButtonDelegate _cancelDelegate;
    ButtonDelegate _goTitleDelegate;


    public void SetUI(string subject, ButtonDelegate windowDel, ButtonDelegate titleDel, string cancelBtnText = "â������(���)", string titleBtnText = "Ÿ��Ʋ�� ����")
    {
        _subject.text = subject;
        _cancelDelegate = windowDel;
        _goTitleDelegate = titleDel;
        _cancelBtnText.text = cancelBtnText;
        _goTitleBtnText.text = titleBtnText;
    }

    public void OnPressWindowButton()
    {
        if (_cancelDelegate != null)
        {
            _cancelDelegate();
        }
        /*else
        {
            PopupManager.Instance.ClosePopup();
        }*/
    }

    public void OnPressTitleButton()
    {
        if (_goTitleDelegate != null)
        {
            _goTitleDelegate();
        }
        /*else
        {
            PopupManager.Instance.ClosePopup();
        }*/
    }

    public void OnPressX()
    {
        PopupManager.Instance.ClosePopup();
        //Ÿ�ӽ�����?
        Time.timeScale = 1f;
    }
}
