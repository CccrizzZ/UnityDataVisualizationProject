using UnityEngine;

public class OrbitalCamera : MonoBehaviour
{

    Transform CameraTransform;

    [SerializeField] Transform TargetTransform;
    Transform ParentTransform;


    public bool CameraDisabled = false;

    Vector3 LocalRotation;


    // parameters
    [SerializeField, Range(0f,100f)] float CameraDistance = 50f;
    [SerializeField, Range(1f,5f)] float MouseSensitivity = 4f;
    [SerializeField, Range(1f,5f)] float ScrollSensitivity = 2f;
    [SerializeField, Range(5f,20f)] float OrbitDampening = 10f;
    [SerializeField, Range(1f,10f)] float ScrollDampening = 5f;


    void Start()
    {
        // set the camera transform
        CameraTransform = transform;

        // set the parent transform;
        ParentTransform = transform.parent;

    }


    void Update() 
    {


        if (Input.GetMouseButton(0))
        {
            CameraDisabled = false;
        }
        else
        {
            CameraDisabled = true;
        }

    }


    // need the camera to be rendered after everything else
    void LateUpdate()
    {
        // transform.LookAt(TargetTransform);


        // unlock camera / lock camera
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            CameraDisabled = !CameraDisabled;
        }

        if (!CameraDisabled)
        {

            // rotation of the camera based on mouse coordinates
            if (Input.GetAxis("Mouse X") != 0 || Input.GetAxis("Mouse Y") != 0)
            {
                // rotate
                LocalRotation.x += Input.GetAxis("Mouse X") * MouseSensitivity;
                LocalRotation.y += Input.GetAxis("Mouse Y") * MouseSensitivity;

                // clamp rotation
                LocalRotation.y = Mathf.Clamp(LocalRotation.y, 0f , 90f);

                // zoom input from our mouse scroll wheel
                if (Input.GetAxis("Mouse ScrollWheel") != 0f)
                {

                    // create scroll amount related to scroll sensitivity
                    float ScrollAmount = Input.GetAxis("Mouse ScrollWheel") * ScrollSensitivity;

                    // camera zoom faster the further away from the target
                    ScrollAmount *= (CameraDistance * 0.3f);

                    CameraDistance += ScrollAmount * -1f;

                    // clamp camera distance
                    CameraDistance = Mathf.Clamp(CameraDistance, 10f, 150f);

                }
            }
        }

        // actuall camera rig tranformation 
        Quaternion QT = Quaternion.Euler(LocalRotation.y, LocalRotation.x, 0);

        // rotate camera parent 
        ParentTransform.rotation = Quaternion.Lerp(ParentTransform.rotation, QT, Time.deltaTime * OrbitDampening);

        // move camera
        if (CameraTransform.localPosition.z != CameraDistance * 1f)
        {
            CameraTransform.localPosition = new Vector3(0f, 0f, Mathf.Lerp(CameraTransform.localPosition.z, CameraDistance * -1f, Time.deltaTime * ScrollDampening));
        
        }


    }
}
