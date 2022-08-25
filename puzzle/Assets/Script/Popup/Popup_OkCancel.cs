using UnityEngine;

public class Popup_OkCancel : MonoBehaviour
{
    [SerializeField]
    UILabel _subject;
    [SerializeField]
    UILabel _body;
    [SerializeField]
    UILabel _okBtnText;
    [SerializeField]
    UILabel _cancelBtnText;
    ButtonDelegate _okDelegate;
    ButtonDelegate _cancelDelegate;


    public void SetUI(string subject, string body, ButtonDelegate okDel, ButtonDelegate cancelDel, string okBtnText = "OK", string cancelBtnText = "Cancel")
    {
        _subject.text = subject;
        _body.text = body;
        _okDelegate = okDel;
        _cancelDelegate = cancelDel;
        _okBtnText.text = okBtnText;
        _cancelBtnText.text = cancelBtnText;
    }

    public void OnPressOK()
    {
        if(_okDelegate != null)
        {
            _okDelegate();
        }
        else
        {
            PopupManager.Instance.ClosePopup();
        }
    }

    public void OnPressCancel()
    {
        if(_cancelDelegate != null)
        {
            _cancelDelegate();
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
