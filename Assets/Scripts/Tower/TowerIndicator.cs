using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerIndicator : MonoBehaviour
{

    // Materials
    [SerializeField] Material Normal;
    [SerializeField] Material Highlight;


    // References
    MeshRenderer mRenderer;
    Canvas CanvasRef;
    public GameObject TowerControlPopup;

    public Tower tower;

    // flag
    bool CanInteract;

    void Start()
    {
        
        // set references
        mRenderer = GetComponent<MeshRenderer>();

        
        if (GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>() == null) return;
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

        // change color to highlight
        mRenderer.material = Highlight;



    }

    void OnMouseExit() 
    {
        // set flag
        CanInteract = false;

        // change color to normal
        mRenderer.material = Normal;
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



        // change to normal color after clicked
        mRenderer.material = Normal;



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

        if (TowerControlPopup != null && tower != null)
        {
            // create new popup
            var TowerPopup = Instantiate(TowerControlPopup);
            var PopupControlPanelScript = TowerPopup.GetComponent<TowerControlPanel>();

            // set tower controller to popup
            PopupControlPanelScript.AddSingleModuleToArray(tower);



            // append to canvas
            TowerPopup.transform.SetParent(CanvasRef.transform, false);

            
        }
    }


}
