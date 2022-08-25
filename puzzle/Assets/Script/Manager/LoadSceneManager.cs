using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneManager : DontDestroy<LoadSceneManager>
{
    public enum SceneState
    {
        None = -1,
        Lobby,
        Game,
    }

    /*[SerializeField]
    UILabel _progressLabel;
    [SerializeField]
    UIProgressBar _loadingProgress;*/
    AsyncOperation _loadingInfo;

    SceneState _scene;
    SceneState _loadScene = SceneState.None;

    public SceneState Scene { get { return _scene; } }

    public void LoadSceneAsync(SceneState scene)
    {
        if (_loadScene != SceneState.None) return;
        _loadScene = scene;
        _loadingInfo = SceneManager.LoadSceneAsync((int)scene);
        gameObject.SetActive(true);      
    }

    protected override void OnStart()
    {
        gameObject.SetActive(false);
    }

    void HideUI()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(_loadingInfo != null)
        {
            if(_loadingInfo.isDone)
            {
                _scene = _loadScene;
                _loadScene = SceneState.None;
                _loadingInfo = null;
                //_loadingProgress.value = 1f;
                //_progressLabel.text = "100%";
                Invoke("HideUI", 1.5f);
            }
            else
            {
                //_loadingProgress.value = _loadingInfo.progress;
                //_progressLabel.text = Mathf.RoundToInt(_loadingInfo.progress * 100f).ToString();
            }
        }
    }
}
