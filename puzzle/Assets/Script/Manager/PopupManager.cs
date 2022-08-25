using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

public delegate void ButtonDelegate();
public class PopupManager : DontDestroy<PopupManager>
{
    [SerializeField]
    GameObject _popupOkCancelPrefab;
    [SerializeField]
    GameObject _popupOkPrefab;
    [SerializeField]
    GameObject _popupExitPrefab;

    int _popupDepth = 100;
    int _popupDepthGap = 10;
    List<GameObject> _popupList = new List<GameObject>();


    public void OpenPopup_OkCancel(string subject, string body, ButtonDelegate okDel, ButtonDelegate cancelDel, string okBtnText = "OK", string cancelBtnText = "Cancel")
    {
        var obj = Instantiate(_popupOkCancelPrefab);
        var popup = obj.GetComponent<Popup_OkCancel>();
        var panels = obj.GetComponentsInChildren<UIPanel>();
        for(int i = 0; i < panels.Length; i++)
        {
            panels[i].depth = _popupDepth + _popupList.Count * _popupDepthGap + i;
        }
        popup.SetUI(subject, body, okDel, cancelDel, okBtnText, cancelBtnText);
        _popupList.Add(obj);
    }

    public void OpenPopup_Ok(string subject, string body, ButtonDelegate okDel,string okBtnText = "OK")
    {
        var obj = Instantiate(_popupOkPrefab);
        var popup = obj.GetComponent<Popup_Ok>();
        var panels = obj.GetComponentsInChildren<UIPanel>();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].depth = _popupDepth + _popupList.Count * _popupDepthGap + i;
        }
        popup.SetUI(subject, body, okDel, okBtnText);
        _popupList.Add(obj);
    }

    public void OpenPopup_Exit(string subject, ButtonDelegate ExitToWindowDel, ButtonDelegate ExitToTitleDel, string windowBtnText = "바탕화면으로 나가기", string titleBtnText = "타이틀로 가기")
    {
        var obj = Instantiate(_popupExitPrefab);
        var popup = obj.GetComponent<Popup_Exit>();
        var panels = obj.GetComponentsInChildren<UIPanel>();
        for (int i = 0; i < panels.Length; i++)
        {
            panels[i].depth = _popupDepth + _popupList.Count * _popupDepthGap + i;
        }
        popup.SetUI(subject, ExitToWindowDel, ExitToTitleDel, windowBtnText, titleBtnText);
        _popupList.Add(obj);
    }


    public void ClosePopup()
    {
        if(_popupList.Count > 0)
        {
            Destroy(_popupList[_popupList.Count - 1].gameObject);
            _popupList.RemoveAt(_popupList.Count - 1);
        }
    }

    protected override void OnStart()
    {
        _popupOkCancelPrefab = Resources.Load("Popup/Popup_OkCancel") as GameObject;
        _popupOkPrefab = Resources.Load("Popup/Popup_Ok") as GameObject;
        _popupExitPrefab = Resources.Load("Popup/Popup_Exit") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(_popupList.Count > 0)
            {
                ClosePopup();
                if(Time.timeScale == 0f)
                    Time.timeScale = 1f;
            }
            else
            {
                switch(LoadSceneManager.Instance.Scene)
                {
                    case LoadSceneManager.SceneState.Lobby:
                        OpenPopup_OkCancel("[000000]안내", "[000000]정말로 게임을 종료하시겠습니까?", () =>
                        {
#if UNITY_EDITOR
                            EditorApplication.isPlaying = false;
                            ClosePopup();
#else
                            Application.Quit();
#endif
                            ClosePopup();
                        }, null, "예", "아니오");
                        break;                   
                    case LoadSceneManager.SceneState.Game:
                        if (Time.timeScale == 1f)
                            Time.timeScale = 0f;
                        OpenPopup_Exit("[000000]게임종료", () =>
                        {
#if UNITY_EDITOR
                            EditorApplication.isPlaying = false;
                            ClosePopup();
#else
                            Application.Quit();
#endif
                            ClosePopup();
                        }, () => LoadSceneManager.Instance.LoadSceneAsync(LoadSceneManager.SceneState.Lobby));                        
                        break;
                }
            }
        }
    }
}
