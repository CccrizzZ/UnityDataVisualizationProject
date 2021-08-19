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

    public TowerIndicator IndicatorRef;


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
        if (AllCablesArr.Count == 0) return;

        foreach (var item in AllCablesArr)
        {
            if(!item.isBothCableOn())continue;
            item.TurnOffBothCable();
        }

        IndicatorRef.SetToOffColor();


        isOn = false;
    }

    public void TurnOnTower()
    {
        
        if (AllCablesArr.Count == 0) return;

        foreach (var item in AllCablesArr)
        {
            if(item.isBothCableOn())continue;
            item.TurnOnBothCable();
        }



        IndicatorRef.SetToNormalColor();
    
        isOn = true;
    }



    // determine if all cable connected are on
    public bool IsAllCablesOn()
    {        
        // iterate all cable arr
        foreach (var item in AllCablesArr)
        {
            
            // if one of the cable is off returns false
            if (item.isBothCableOn())
            {
                continue;
            }
            else
            {
                return false;
            }

        }

        return true;
    }

    // return true if one of the cables is on
    // return false if non of the cables are on
    public bool AreSomeCablesOn()
    {        
        // iterate all cable arr
        foreach (var item in AllCablesArr)
        {
            
            // if one of the cable is off returns false
            if (item.isBothCableOn())
            {
                return true;
            }
            else
            {
                continue;
            }

        }

        return false;
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
