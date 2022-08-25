using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class piecesScript : MonoBehaviour
{
    public Image fade;

    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;

    private GameObject CamObject;

    static List<string> RightPositionObject;

    static string SceneName;

    // Start is called before the first frame update
    void Start()
    {
        CamObject = GameObject.Find("Main Camera");
        RightPositionObject = new();

        RightPosition = transform.position;
        for (int i = 1; i < 80; i++)
        {
            if (i == Random.Range(0, 81))
                transform.position = new Vector3(Random.Range(-8.06f, -4.14f), Random.Range(2.87f, -4f));
            else
                transform.position = new Vector3(Random.Range(3.84f, 7.88f), Random.Range(2.87f, -4f));
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(transform.position, RightPosition) < 0.5f)
        {
            if (!Selected)
            {
                if (InRightPosition == false)
                {
                    transform.position = RightPosition;
                    InRightPosition = true;
                    GetComponent<SortingGroup>().sortingOrder = 0;
                }
                else
                {
                    if (!RightPositionObject.Contains(transform.gameObject.name))
                    {
                        RightPositionObject.Add(transform.gameObject.name);
                        LoadEventScene(RightPositionObject.Count);
                    }
                }
            }
        }
    }

    void LoadEventScene(int num)
    {
        switch (num)
        {
            case 1: //테스트용
                SceneName = "Event1";
                CamObject.GetComponent<PlayMusicOperator>().PlayBGM("event0");
                break;

            case 20:
                SceneName = "Event1";
                CamObject.GetComponent<PlayMusicOperator>().PlayBGM("event1");
                break;

            case 40:
                SceneName = "Event2";
                CamObject.GetComponent<PlayMusicOperator>().PlayBGM("event2");
                break;

            case 60:
                SceneName = "Event3";
                CamObject.GetComponent<PlayMusicOperator>().PlayBGM("event3");
                break;

            case 80:
                SceneName = "Event4";
                break;
        }
    }

    IEnumerator FadeInFlow()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Puzzle");
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
        SceneManager.LoadScene("Main");
        yield return null;
    }
}
