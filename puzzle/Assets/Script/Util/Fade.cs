using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public UnityEngine.UI.Image fade;
    float fades = 1.0f;
    float time = 0f;


    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if(fades < 255.0f && time >= 0.5f)
        {
            fades += 0.1f;
            fade.color = new Color(0, 0, 0, fades);
            time = 0;
        }
        else if(fades >= 255.0f)
        {
            time = 0;
            //다음신으로 넘어가기
        }
    }
}
