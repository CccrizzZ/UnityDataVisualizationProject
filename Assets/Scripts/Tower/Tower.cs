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

    
    // for auto cable detection
    public List<CableController> AllCablesArr;



    void Start()
    {
        isOn = true;
    }

    void Update()
    {
        
    }



    // turn off all cables in cable list
    public void TurnOffTower()
    {
        print("turning off");
        if (AllCablesArr.Count == 0) return;
        print("turning off2");

        foreach (var item in AllCablesArr)
        {
            if(!item.isBothCableOn())continue;
            item.TurnOffBothCable();
        }
    }

    public void TurnOnTower()
    {
        
        if (AllCablesArr.Count == 0) return;

        foreach (var item in AllCablesArr)
        {
            if(item.isBothCableOn())continue;
            item.TurnOnBothCable();
        }
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
