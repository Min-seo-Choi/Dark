using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Test : MonoBehaviour
{
    public Image fade;
    public Canvas canvas;

    void start()
    {

    }

    public void OnClick()
    {
        canvas.gameObject.SetActive(false);
        StartCoroutine(FadeInFlow());
    } 

    IEnumerator FadeInFlow()
    {
        fade.gameObject.SetActive(true);
        float time = 0f;
        Color alpha = fade.color;
        while (alpha.a < 1f)
        {
            time += 0.01f;
            alpha.a = Mathf.Lerp(0, 1, time);
            fade.color = alpha;
            yield return null;
        }
        SceneManager.LoadScene("Main");
        yield return null;
    }
}
