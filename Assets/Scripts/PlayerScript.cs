using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{    

    [SerializeField] private Camera cam;
    [SerializeField] private GameObject target;

    [SerializeField, Range(20f,150f)]
    float distance;

    Vector3 StartPosition;

    Vector3 PreviousPosition;

    Vector3 SavedPosition;
    Vector3 SavedRotation; 


    void Start()
    {
        StartPosition = transform.position;
        distance = 150.0f;
    }

    void Update()
    {
        if (GameObject.FindGameObjectsWithTag("InfoPopup").Length > 0)return;

        if (Input.GetMouseButtonDown(0))
        {
            PreviousPosition = cam.ScreenToViewportPoint(Input.mousePosition);

        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            Vector3 direction = PreviousPosition - newPosition;

            // rotation float
            float rotationAroundYAxis = -direction.x * 360; // camera moves horizontally
            float rotationAroundXAxis = direction.y * 90; // camera moves vertically
            
            
            cam.transform.position = target.transform.position;


            cam.transform.Rotate(new Vector3(1,0,0), rotationAroundXAxis);
            cam.transform.Rotate(new Vector3(0,1,0), rotationAroundYAxis, Space.World);
            cam.transform.Translate(new Vector3(0, 25, -distance));

            // float tempY = cam.transform.rotation.eulerAngles.y;
            // float tempX = cam.transform.rotation.eulerAngles.x;
            // tempY = Mathf.Clamp(tempY, 0, 90f);
            
            // cam.transform.rotation = Quaternion.Euler(tempX, tempY, 0);




            PreviousPosition = cam.ScreenToViewportPoint(Input.mousePosition);
            

            if (cam.transform.position.y <= 10)
            {
                cam.transform.position = new Vector3(cam.transform.position.x, 10, cam.transform.position.z);
                
            }
            else if (cam.transform.position.y >= 100)
            {
                cam.transform.position = new Vector3(cam.transform.position.x, 100, cam.transform.position.z);
            
            }
        }
    }



    public void MoveTo(Transform intransform)
    {
        // save camera position & rotation before click
        SavedPosition = transform.position;
        SavedRotation = transform.rotation.eulerAngles;

        // move player towards the building
        transform.position = intransform.position + new Vector3(0,-10,-40);


        // look at that building
        transform.LookAt(intransform);
    }

    public void ResetPosition()
    {
        // reset player position
        transform.position = SavedPosition;
        transform.rotation = Quaternion.Euler(SavedRotation);

    }

}
