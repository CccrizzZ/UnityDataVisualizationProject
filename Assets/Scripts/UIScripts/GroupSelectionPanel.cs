using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroupSelectionPanel : MonoBehaviour
{

    public List<GameObject> TowerIndicators;

    void Start() 
    {
        // TowerIndicators = new List<GameObject>();
    }



    void ToggleSelectedTower()
    {
        foreach (var item in TowerIndicators)
        {
            item.GetComponent<TowerIndicator>().tower.TurnOnAllCableConnected();       
        }
    }

    public void CloseButtonEvent()
    {
        print(TowerIndicators.Count);


        // set selected tower indicator to its previous color
        foreach (var item in TowerIndicators)
        {
            // print(item.GetComponent<TowerIndicator>().tower.name);
            item.GetComponent<TowerIndicator>().SetToNormalColor();
        }
        

        // clear list
        TowerIndicators.Clear();

        // close panel;
        Destroy(gameObject);
    }


    // group turn on off button event
    public void GroupPowerShutDown()
    {

        foreach (var item in TowerIndicators)
        {
            item.GetComponent<TowerIndicator>().tower.TurnOffAllCableConnected();
        }
    }


    // group turn on button event
    public void GroupPowerTurnOn()
    {

        foreach (var item in TowerIndicators)
        {
            item.GetComponent<TowerIndicator>().tower.TurnOnAllCableConnected();
        }
    }
}
