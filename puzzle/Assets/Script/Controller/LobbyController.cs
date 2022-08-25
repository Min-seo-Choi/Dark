using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class LobbyController : MonoBehaviour
{              
    [SerializeField]
    UIButton[] _menuButtons;
    [SerializeField]
    UIPanel _rulePanel;
   

    public void ShowUIButton(bool setActive)
    {
        for (int i = 0; i < _menuButtons.Length; i++)
        {
            _menuButtons[i].gameObject.SetActive(setActive);
        }
    }

    public void OnRuleButtonClick()
    {      
        _rulePanel.gameObject.SetActive(true);
    }

    public void CloseRulePanel()
    {
        _rulePanel.gameObject.SetActive(false);
    }

    public void OnExitButtonClick()
    {      
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;        
#else
        Application.Quit();
#endif
             
    }

    public void GameStart()
    {
        LoadSceneManager.Instance.LoadSceneAsync(LoadSceneManager.SceneState.Game);
    }

    public void EventScene()
    {
        //LoadSceneManager.Instance.LoadSceneAsync(LoadSceneManager.SceneState.EventScene);
        Debug.Log("게임저장");
    }
   

    // Start is called before the first frame update
    void Start()
    {
        CloseRulePanel();
    }
}
