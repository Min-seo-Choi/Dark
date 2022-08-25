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


    public void SetUI(string subject, ButtonDelegate windowDel, ButtonDelegate titleDel, string cancelBtnText = "창나가기(취소)", string titleBtnText = "타이틀로 가기")
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
        //타임스케일?
        Time.timeScale = 1f;
    }
}
