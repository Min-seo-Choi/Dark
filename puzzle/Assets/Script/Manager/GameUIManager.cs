using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using System.Text;

public class GameUIManager : SingletonMonobehaviour<GameUIManager>
{
    [SerializeField]
    UILabel _progressLabel;
    [SerializeField]
    ReviewEvent _reviewEventPanel;
    [SerializeField]
    EventController _eventController;

    StringBuilder _sb = new StringBuilder();


    public void PressEscape()
    {
        //일시정지
        Time.timeScale = 0f;
        PopupManager.Instance.OpenPopup_Exit("[000000]게임종료", () =>
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
            PopupManager.Instance.ClosePopup();
#else
                            Application.Quit();
#endif
            PopupManager.Instance.ClosePopup();
        }, () => LoadSceneManager.Instance.LoadSceneAsync(LoadSceneManager.SceneState.Lobby));
    }

    public void MixPuzzle()
    {
        //퍼즐섞기
        Debug.Log("퍼즐섞기!");
    }

    public void OnChooseEventSceneButton()
    {
        //이벤트씬 선택창 내려오기
        _reviewEventPanel.Show();

        //선택 후 EventScene UI 띄우기
        
    }  


    // Start is called before the first frame update
    void Start()
    {
        //_eventController.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
               
    }
}
