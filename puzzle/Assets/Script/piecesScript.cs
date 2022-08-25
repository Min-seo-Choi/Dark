using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class piecesScript : MonoBehaviour
{
    private Vector3 RightPosition;
    public bool InRightPosition;
    public bool Selected;


    // Start is called before the first frame update
    void Start()
    {
        RightPosition = transform.position;
        for(int i = 1; i < 81; i++)
        {
            if(i == Random.Range(0, 81))
            {
               transform.position = new Vector3(Random.Range(-8.06f, -4.14f), Random.Range(3.87f, -4f));
                continue;
            }

            transform.position = new Vector3(Random.Range(3.84f, 7.88f), Random.Range(3.87f, -4f));
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
            }
        }
    }
}
