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
        //�Ͻ�����
        Time.timeScale = 0f;
        PopupManager.Instance.OpenPopup_Exit("[000000]��������", () =>
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
        //���񼯱�
        Debug.Log("���񼯱�!");
    }

    public void OnChooseEventSceneButton()
    {
        //�̺�Ʈ�� ����â ��������
        _reviewEventPanel.Show();

        //���� �� EventScene UI ����
        
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
