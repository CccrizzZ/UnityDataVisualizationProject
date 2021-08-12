using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleControlModule : MonoBehaviour
{

    // tower ref
    public Tower tower;

    // cable sockets
    public CableController SocketUp;
    public CableController SocketDown;
    public CableController SocketLeft;
    public CableController SocketRight;

    // switches
    public GameObject SwitchUp;
    public GameObject SwitchDown;
    public GameObject SwitchLeft;
    public GameObject SwitchRight;


    void Start()
    {
        if (tower == null)return;

        InitSockets();
        // InitSwitches();



    }

    void Update()
    {
        
    }


    void InitSockets()
    {
        // determine how many cables being pluged into the tower
        if (tower.CableUp != null)
        {
            SocketUp = tower.CableUp;
            SwitchUp.SetActive(true);
        }

        if (tower.CableDown != null)
        {
            SocketDown = tower.CableDown;
            SwitchDown.SetActive(true);

        }

        if (tower.CableLeft != null)
        {
            SocketLeft = tower.CableLeft;
            SwitchLeft.SetActive(true);

        }

        if (tower.CableRight != null)
        {
            SocketRight = tower.CableRight;
            SwitchRight.SetActive(true);

        }



    }


    void ToggleSocketOnAndOff(CableController socket)
    {
        if (socket.isBothCableOn())
        {
           socket.TurnOffBothCable();
        }
        else
        {
           socket.TurnOnBothCable();
        }
    }


    public void ToggleSocketUp()
    {
        ToggleSocketOnAndOff(SocketUp);
    }

    public void ToggleSocketDown()
    {
        ToggleSocketOnAndOff(SocketDown);
    }

    public void ToggleSocketLeft()
    {
        ToggleSocketOnAndOff(SocketLeft);
    }

    public void ToggleSocketRight()
    {
        ToggleSocketOnAndOff(SocketRight);
    }


    public void MainPowerOffButton()
    {
        tower.TurnOffAllCableConnected();

    }

    public void MainPowerOnButton()
    {
        tower.TurnOnAllCableConnected();

    }
}
