using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Intro_ButtonClickEvent : MonoBehaviour
{
    public Image fade;

    public GameObject HowPlay;
    public Text play_txt;
    public Text how_txt1;
    public Text how_txt2;
    public Text how_txt3;
    public Text exit_txt;

    void Start()
    {
        fade.gameObject.SetActive(false);
    }


    public void PlayTextColorChange()
    {
        if (play_txt.color == Color.white) play_txt.color = Color.black;
        else play_txt.color = Color.white;
    }

    public void HowTextColorChange()
    {
        if (how_txt1.color == Color.white)
        {
            how_txt1.color = Color.black;
            how_txt2.color = Color.black;
            how_txt3.color = Color.black;
        }
        else
        {
            how_txt1.color = Color.white;
            how_txt2.color = Color.white; 
            how_txt3.color = Color.white;
        }
    }

    public void ExitTextColorChange()
    {
        if (exit_txt.color == Color.white) exit_txt.color = Color.black;
        else exit_txt.color = Color.white;
    }


    public void OnClickPlayButton()
    {
        StartCoroutine(FadeInFlow());
    }    
    
    public void OnClickHowButton()
    {
        HowPlay.SetActive(true);
    }     
    
    public void HowToPlayDownButton()
    {
        HowPlay.SetActive(false);
    }    
    
    public void OnClickExitButton()
    {
        Application.Quit();
    }

    IEnumerator FadeInFlow()
    {
        fade.gameObject.SetActive(true);
        float time = 0f;
        Color alpha = fade.color;
        while (alpha.a < 1f)
        {
            time += 0.003f;
            alpha.a = Mathf.Lerp(0, 1, time);
            fade.color = alpha;
            yield return null;
        }
        SceneManager.LoadScene("Main");
        yield return null;
    }
}
