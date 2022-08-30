using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public Image fade;

    void start()
    {

    }

    public void OnClick()
    {
        StartCoroutine(FadeInFlow());
    }    
    
    public void OnClick1()
    {
        StartCoroutine(FadeInFlow());
    }    
    
    public void OnClick2()
    {
        StartCoroutine(FadeInFlow());
    }    
    
    public void OnClick3()
    {
        StartCoroutine(FadeInFlow());
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
