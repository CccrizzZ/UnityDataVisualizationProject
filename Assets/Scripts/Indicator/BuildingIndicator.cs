using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingIndicator : MonoBehaviour
{

    // Materials
    [SerializeField] Material Normal;
    [SerializeField] Material Highlight;

    // References
    MeshRenderer mRenderer;
    public Building TargetBuilding;
    Canvas CanvasRef;
    public GameObject BuildingInfoPopup;

    [SerializeField] Vector3 CameraPosition;


    bool CanInteract;


    void Start()
    {
        
        // set camera position
        CameraPosition = transform.position + new Vector3(0,10,50);


        // set references
        mRenderer = GetComponent<MeshRenderer>();
        if (GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>()==null) return;
        CanvasRef = GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>();

    }


    void Update()
    {
        transform.Rotate(new Vector3(0,0.5f,0));
    }

    void OnMouseEnter()
    {
        
        // return if mouse is already down or a popup already exist
        if (Input.GetMouseButton(0))return;
        if (GameObject.FindGameObjectsWithTag("InfoPopup").Length > 0)return;

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
        if (GameObject.FindGameObjectsWithTag("InfoPopup").Length > 0)return;

        if (CanvasRef == null)return;



        // create new popup
        var InfoPopup = Instantiate(BuildingInfoPopup);

        if (TargetBuilding != null)
        {
            // set info
            InfoPopup.GetComponent<InfoPopupScript>().SetName(TargetBuilding.building_name);
            InfoPopup.GetComponent<InfoPopupScript>().SetInfo(TargetBuilding.building_info);
            InfoPopup.GetComponent<InfoPopupScript>().setConsumption(TargetBuilding.building_consumption);
            
            
        }


        // append to canvas
        InfoPopup.transform.SetParent(CanvasRef.transform, false);


        // change to normal color after clicked
        mRenderer.material = Normal;



        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            // lock the camera to target building 
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().MoveTo(transform);
    
        }

    }


}
