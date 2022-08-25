using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviewEvent : MonoBehaviour
{   
    public void Show()
    {
        gameObject.SetActive(true);

    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }

    public void OnPressFirstEvent()
    {
        //if(진행도가 25퍼 이상이라면) 첫번째 이벤트 다시 보여주기
    }

    public void OnPressSecondEvent()
    {

    }

    public void OnPressThirdEvent()
    {

    }

    public void OnPressFourthEvent()
    {

    }


    public void OnPressX()
    {
        gameObject.SetActive(false);
    }

    // Start is called before the first frame update
    void Start()
    {
        Hide();
    }

    // Update is called once per frame
    void Update()
    {
        //이벤트 선택?
    }
}
