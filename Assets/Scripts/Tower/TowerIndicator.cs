using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIndicator : MonoBehaviour
{

    // Materials
    [SerializeField] Material Normal;
    [SerializeField] Material Highlight;
    [SerializeField] Material Off;
    [SerializeField] Material PreviousColor;


    public GameObject SelectIndicatorRef;



    // References
    MeshRenderer mRenderer;
    Canvas CanvasRef;
    // public GameObject TowerControlPopup;
    public GameObject TowerControlModule;


    public Tower tower;

    // flag
    bool CanInteract;

    void Start()
    {
        
        // set references
        mRenderer = GetComponent<MeshRenderer>();

        
        if (!GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>()) return;
        CanvasRef = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();



    }

    void Update()
    {
        // rotate
        transform.Rotate(new Vector3(0,0.5f,0));
    }





    void OnMouseEnter()
    {
        
        // print("Entered");

        // // return if mouse is already down or a popup already exist
        if (IsMouseButtonAlreadyDown())return;
        if (IsTherePopup())return;

        // set flag
        CanInteract = true;
 
        // set color
        // SetToHighlightColor();


        // turn select indicator on
        SelectIndicatorRef.SetActive(true);
    }

    void OnMouseExit() 
    {

        // return if there is already a popup exist
        if (IsTherePopup())return;

        // set flag
        CanInteract = false;


        SelectIndicatorRef.SetActive(false);

        // SetToColorAccordingToTower();
    }

    void OnMouseUp()
    {
        // return if flag is false
        if (!CanInteract)return;

        // return if there is already a popup exist
        if (IsTherePopup())return;
        

        // return if no canvas
        if (CanvasRef == null)return;


        InitPopup();

        // // set color
        // SetToNormalColor();
        // SetToColorAccordingToTower();


    }



    void SetToColorAccordingToTower()
    {
        if (tower.isOn == false)
        {
            // set to off color
            SetToOffColor();
        }
        else
        {
            // set to normal color
            SetToNormalColor();
            
        }

    }

    // determine if the left mouse button is down
    bool IsMouseButtonAlreadyDown()
    {
        return Input.GetMouseButton(0);
    }


    // determine if there is a info popup
    bool IsTherePopup()
    {
        return GameObject.FindGameObjectsWithTag("Popup").Length > 0;
    }


    void InitPopup()
    {

        if (TowerControlModule != null && tower != null)
        {
            // create new popup
            // var TowerPopup = Instantiate(TowerControlPopup);
            // var PopupControlPanelScript = TowerPopup.GetComponent<TowerControlPanel>();

            // // set tower controller to popup
            // PopupControlPanelScript.AddSingleModuleToArray(tower);



            // append to canvas
            // TowerPopup.transform.SetParent(CanvasRef.transform, false);


            // create control module
            var ControlModule = Instantiate(TowerControlModule);
            ControlModule.GetComponent<SingleControlModule>().tower = tower;


            // append to canvas
            ControlModule.transform.SetParent(CanvasRef.transform, false);







        }
    }


    // colors
    public void SetToNormalColor()
    {

        // change to normal color after clicked
        mRenderer.material = Normal;

    }

    public void SetToHighlightColor()
    {
        SavePreviousColor();

        // change color to highlight
        mRenderer.material = Highlight;

    }

    public void SetToOffColor()
    {
        // change color to highlight
        mRenderer.material = Highlight;

    }


    public void SetToPreviousColor()
    {
        // change color to highlight
        mRenderer.material = PreviousColor;

    }

    void SavePreviousColor()
    {
        // save previous color
        PreviousColor = mRenderer.material;
    }



    public string GetTowerName()
    {
        return tower.name;
    }




    public void UpdateIndicator()
    {
        tower.UpdateIndicatorColor();
    }
}
