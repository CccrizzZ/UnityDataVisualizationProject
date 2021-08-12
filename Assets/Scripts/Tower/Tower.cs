using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{


    public bool isOn;



    public CableController CableUp;
    public CableController CableDown;
    public CableController CableLeft;
    public CableController CableRight;



    void Start()
    {
        isOn = true;
    }

    void Update()
    {
        
    }


    public void TurnOffAllCableConnected()
    {
        if (CableUp != null && CableUp.isBothCableOn())
        {
            CableUp.TurnOffBothCable();

        }

        if (CableDown != null && CableDown.isBothCableOn())
        {
            CableDown.TurnOffBothCable();
        }

        if (CableLeft != null && CableLeft.isBothCableOn())
        {
            CableLeft.TurnOffBothCable();

        }

        if (CableRight != null && CableRight.isBothCableOn())
        {
            CableRight.TurnOffBothCable();
        }

        isOn = false;

    }

    public void TurnOnAllCableConnected()
    {
        if (CableUp != null && !CableUp.isBothCableOn())
        {
            CableUp.TurnOnBothCable();

        }

        if (CableDown != null && !CableDown.isBothCableOn())
        {
            CableDown.TurnOnBothCable();
        }

        if (CableLeft != null && !CableLeft.isBothCableOn())
        {
            CableLeft.TurnOnBothCable();

        }

        if (CableRight != null && !CableRight.isBothCableOn())
        {
            CableRight.TurnOnBothCable();
        }

        isOn = true;
        
    }

}
