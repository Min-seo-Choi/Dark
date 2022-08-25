using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class PuzzleHandler : MonoBehaviour
{
    public GameObject SelectedPiece;
    int OIL = 1;

    GameObject obj;

    // Start is called before the first frame update
    void Start()
    {
        obj = GameObject.Find("Memory");
    }

    // Update is called once per frame
    void Update()
    {
        if (obj.activeSelf == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
                if (hit.transform.CompareTag("Puzzle"))
                {
                    if (!hit.transform.GetComponent<piecesScript>().InRightPosition)
                    {
                        SelectedPiece = hit.transform.gameObject;
                        SelectedPiece.GetComponent<piecesScript>().Selected = true;
                        SelectedPiece.GetComponent<SortingGroup>().sortingOrder = OIL;
                        OIL++;
                    }
                }
            }
            if (Input.GetMouseButtonUp(0))
            {
                if (SelectedPiece != null)
                {
                    SelectedPiece.GetComponent<piecesScript>().Selected = false;
                    SelectedPiece = null;
                }
            }


            if (SelectedPiece != null)
            {
                Vector3 MousePoint = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                SelectedPiece.transform.position = new Vector3(MousePoint.x, MousePoint.y, 0);
            }
        }        
    }
}
