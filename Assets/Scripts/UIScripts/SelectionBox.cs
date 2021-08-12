using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectionBox : MonoBehaviour
{

    public RectTransform SelectBox;
    public Camera MainCamera;
    List<GameObject> AllTowerIndicatorList;
    List<GameObject> SelectList;
    Vector2 MouseStartPos;
    Canvas MainCanvas;





    void Start()
    {
        // initiallize
        SelectList = new List<GameObject>();
        AllTowerIndicatorList = new List<GameObject>();
        MainCanvas = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

        // get camera
        MainCamera = Camera.main;

        // get all tower indicator
        foreach (var item in GameObject.FindGameObjectsWithTag("Indicator"))
        {
            AllTowerIndicatorList.Add(item);
        }

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

        // if Lshift is up
        if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            ReleaseSelectionBox();
        }

        // mouse and Lshift held down
        if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift))
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


        // get min and max position of selection box
        Vector2 min = SelectBox.anchoredPosition - (SelectBox.sizeDelta / 2);
        Vector2 max = SelectBox.anchoredPosition + (SelectBox.sizeDelta / 2);


        // get all tower indicator inside selection box 
        foreach (var item in AllTowerIndicatorList)
        {
            // convert indicator position to screen position
            Vector3 screenPos = MainCamera.WorldToScreenPoint(item.transform.position);
        


            // highlight if in selection box
            if (IsInSelectionBox(screenPos, min, max))
            {
                item.GetComponent<TowerIndicator>().SetToHighlightColor();
            }
            else
            {
                item.GetComponent<TowerIndicator>().SetToNormalColor();
                
            }
        }


    }


    void ReleaseSelectionBox()
    {

        if (!SelectBox.gameObject.activeSelf) return;

        // get min and max position of selection box
        Vector2 min = SelectBox.anchoredPosition - (SelectBox.sizeDelta / 2);
        Vector2 max = SelectBox.anchoredPosition + (SelectBox.sizeDelta / 2);


        // get all tower indicator inside selection box 
        foreach (var item in AllTowerIndicatorList)
        {
            // convert indicator position to screen position
            Vector3 screenPos = MainCamera.WorldToScreenPoint(item.transform.position);
            
            // 
            if (IsInSelectionBox(screenPos, min, max))
            {
                // SelectList.Add(item);
                print(item.GetComponent<TowerIndicator>().tower.name);
                
            }
        }
        
        // turn off selection box
        SelectBox.gameObject.SetActive(false);

    }


    // return true if screenPos is in selection box
    bool IsInSelectionBox(Vector3 screenPos, Vector2 min, Vector3 max)
    {
        return (screenPos.x > min.x && screenPos.x < max.x && screenPos.y > min.y && screenPos.y < max.y);
    }


}
