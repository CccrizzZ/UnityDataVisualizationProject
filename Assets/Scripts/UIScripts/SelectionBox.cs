using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{

    public RectTransform SelectBox;

    List<BuildingIndicator> SelectList;


    Vector2 MouseStartPos;


    void Start()
    {
        SelectList = new List<BuildingIndicator>();
        

    }

    void Update()
    {

        // mouse down
        if (Input.GetMouseButtonDown(0))
        {

            // save the starting mouse position
            MouseStartPos = Input.mousePosition;
            


        }  

        // mouse up
        if (Input.GetMouseButtonUp(0))
        {
            ReleaseSelectionBox();
        }

        // mouse held down
        if (Input.GetMouseButton(0))
        {
            UpdateSelectionBox(Input.mousePosition);
        }  
    }


    // selection box update
    void UpdateSelectionBox(Vector2 curMousePos)
    {
        // return if no selection box
        if (SelectBox == null) return;

        // if the selection box is not active set it to active
        if (!SelectBox.gameObject.activeInHierarchy)
        {
            SelectBox.gameObject.SetActive(true);
        }

        // set width and height of the selection box 
        float width = curMousePos.x - MouseStartPos.x;
        float height = curMousePos.y - MouseStartPos.y;

        // set size and position
        SelectBox.sizeDelta = new Vector2(Mathf.Abs(width), Mathf.Abs(height));
        SelectBox.anchoredPosition = MouseStartPos + new Vector2(width/2, height/2);


    }


    void ReleaseSelectionBox()
    {
        SelectBox.gameObject.SetActive(false);

    }




}
