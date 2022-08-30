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

    static GameObject[] obj;
    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.FindGameObjectsWithTag("Puzzle");
        Memory.SetActive(false);
        fade.gameObject.SetActive(false);
    }

    public void OnClickBackButton()
    {
        StartCoroutine(FadeInFlow());
    }

    public void OnClickReFreshButton()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if (!obj[i].transform.GetComponent<piecesScript>().InRightPosition)
            {
                if (i == Random.Range(0, 81))
                    obj[i].transform.position = new Vector3(Random.Range(-8.06f, -4.14f), Random.Range(2.87f, -4f));
                else
                    obj[i].transform.position = new Vector3(Random.Range(3.84f, 7.88f), Random.Range(2.87f, -4f));
            }
        }
    }

    public void OnClickReplayExitButton()
    {
        Memory.SetActive(false);
    }

    public void OnClickReplayButton()
    {
        if (Memory.activeSelf == true) Memory.SetActive(false);
        else
        {
            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].GetComponent<piecesScript>().Selected = false;
                obj[i].GetComponent<SortingGroup>().sortingOrder = 0;
            }

            Memory.SetActive(true);
        }
    }

    IEnumerator FadeInFlow()
    {        
        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].GetComponent<piecesScript>().Selected = false;
            obj[i].GetComponent<SortingGroup>().sortingOrder = 0;
        }

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
