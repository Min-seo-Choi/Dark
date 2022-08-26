using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering;

public class Main_BackGround : MonoBehaviour
{
    public GameObject ending;
    public Image fade;

    public Sprite background_1;
    public Sprite background_2;
    public Sprite background_3;
    public Sprite background_4;

    SpriteRenderer origin;

    // Start is called before the first frame update
    void Start()
    {
       origin = gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!string.IsNullOrEmpty(PlayerPrefs.GetString("EventScene")))
        {
            switch (PlayerPrefs.GetString("EventScene"))
            {
                case "Event1":
                    origin.sprite = background_1;
                    break;

                case "Event2":
                    origin.sprite = background_2;
                    break;

                case "Event3":
                    origin.sprite = background_3;
                    break;

                case "Event4":
                    origin.sprite = background_4;
                    Ending();
                    break;
            }
        }
    }

    void Ending()
    {
        StartCoroutine(FadeInFlow());
        ending.SetActive(true);
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
        yield return null;
    }
}
