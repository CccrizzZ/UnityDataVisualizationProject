using UnityEngine;

public class StreetViewCamera : MonoBehaviour
{
    public float speed = 3.5f;
    private float X;
    private float Y;

    void Update() 
    {

        // if mouse is down and Lshift is up
        if(Input.GetMouseButton(0) && !Input.GetKey(KeyCode.LeftShift)) 
        {
            transform.Rotate(new Vector3(Input.GetAxis("Mouse Y") * speed, -Input.GetAxis("Mouse X") * speed, 0));
            X = transform.rotation.eulerAngles.x;
            Y = transform.rotation.eulerAngles.y;
            transform.rotation = Quaternion.Euler(X, Y, 0);
        }


    }




}
