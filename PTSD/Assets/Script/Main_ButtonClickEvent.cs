using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Rendering;

public class Main_ButtonClickEvent : MonoBehaviour
{
    public GameObject Memory;

    public Image fade;


    // Start is called before the first frame update
    void Start()
    {
        Memory.SetActive(false);
        fade.gameObject.SetActive(false);
    }

    public void OnClickBackButton()
    {
        StartCoroutine(FadeInFlow());
    }

    public void OnClickReFreshButton()
    {
        Debug.Log("Refresh");
    }

    public void OnClickReplayButton()
    {
        if (Memory.activeSelf == true) Memory.SetActive(false);
        else
        {
            GetComponent<SortingGroup>().sortingOrder = 0;
            Memory.SetActive(true);
        }
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
        SceneManager.LoadScene("Intro");
        yield return null;
    }
}
