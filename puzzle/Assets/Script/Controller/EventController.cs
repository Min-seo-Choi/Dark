using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventController : MonoBehaviour
{
    [SerializeField]
    SpriteRenderer _eventSprite;
    [SerializeField]
    UIButton[] _uiButton;

    bool[] isPlayed = new bool[4];

    public void Show()
    {
        _eventSprite.gameObject.SetActive(true);
    }

    public void Hide()
    {
        _eventSprite.gameObject.SetActive(false);
    }

    public void uiButtonShow(bool isActive)
    {
        for(int i = 0; i < 3; i++)
        {
            _uiButton[i].gameObject.SetActive(isActive);
        }
    }

    public void PlayerInput(int num)
    {
        if(Input.GetMouseButtonDown(0))
        {
            isPlayed[num] = true;
            Hide();
            uiButtonShow(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //_eventSprite = GetComponent<SpriteRenderer>();
        Hide();       
        for(int i = 0; i < 4; i++)
        {
            isPlayed[i] = false;
        }
    }

    private void Update()
    {
        //switch (GameUIManager.Instance.ProgressScore)
        //{
        //    case 20:
        //        if(isPlayed[0] == false)
        //        {
        //            uiButtonShow(false);
        //            Show();
        //            _eventSprite.sprite = Resources.Load<Sprite>("Art/Game/나레이션01");
        //            PlayerInput(0);                   
        //        }              
        //        break;
        //    case 40:
        //        if (isPlayed[1] == false)
        //        {
        //            uiButtonShow(false);
        //            Show();
        //            _eventSprite.sprite = Resources.Load<Sprite>("Art/Game/나레이션02");
        //            PlayerInput(1);
        //        }
        //        break;
                
        //    case 60:
        //        if (isPlayed[2] == false)
        //        {
        //            uiButtonShow(false);
        //            Show();
        //            _eventSprite.sprite = Resources.Load<Sprite>("Art/Game/나레이션03");
        //            PlayerInput(2);
        //        }              
        //        break;
        //    case 80:
        //        if (isPlayed[3] == false)
        //        {
        //            uiButtonShow(false);
        //            Show();
        //            _eventSprite.sprite = Resources.Load<Sprite>("Art/Game/나레이션04");
        //            PlayerInput(3);
        //        }
                
        //        //엔딩화면?
        //        if(isPlayed[3] == true)
        //        {

        //        }
        //        break;
        //}
    }

}
