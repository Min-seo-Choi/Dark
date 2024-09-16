using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EventLoadHelper : MonoBehaviour
{
    public Image event1;
    public Image event2;
    public Image event3;
    public Image event4;

    public Image fade;

    static GameObject[] obj;
    static string SceneName;

    static List<string> RightPositionObject;

    void Start()
    {
        obj = GameObject.FindGameObjectsWithTag("Puzzle");
    }

    // Update is called once per frame
    void Update()
    {
        switch (PlayerPrefs.GetString("EventScene"))
        {
            case "Event1":
                event1.gameObject.SetActive(false);
                break;
                
            case "Event2":
                event1.gameObject.SetActive(false);
                event2.gameObject.SetActive(false);
                break;   

            case "Event3":
                event1.gameObject.SetActive(false);
                event2.gameObject.SetActive(false);
                event3.gameObject.SetActive(false);
                break;  
                
            case "Event4":
                event1.gameObject.SetActive(false);
                event2.gameObject.SetActive(false);
                event3.gameObject.SetActive(false);
                event4.gameObject.SetActive(false);
                break;
        }
    }

    public void OnClickEventScene1()
    {
        SceneName = "Event1";
        StartCoroutine(FadeInFlow());
    }    
    
    public void OnClickEventScene2()
    {
        SceneName = "Event2";
        StartCoroutine(FadeInFlow());
    }    
    
    public void OnClickEventScene3()
    {
        SceneName = "Event3";
        StartCoroutine(FadeInFlow());
    }    
    
    public void OnClickEventScene4()
    {
        SceneName = "Event4";
        StartCoroutine(FadeInFlow());
    }

    IEnumerator FadeInFlow()
    {
        string temp = string.Empty;

        for (int i = 0; i < obj.Length; i++)
        {
            obj[i].GetComponent<piecesScript>().Selected = false;
            obj[i].GetComponent<SortingGroup>().sortingOrder = 0;
            if (obj[i].transform.GetComponent<piecesScript>().InRightPosition)
            {
                if (string.IsNullOrEmpty(temp)) temp = obj[i].name;
                else temp += "," + obj[i].name;
            }            
        }
        PlayerPrefs.SetString("Puzzle", temp);

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
        SceneManager.LoadScene(SceneName);
        yield return null;
    }
}
