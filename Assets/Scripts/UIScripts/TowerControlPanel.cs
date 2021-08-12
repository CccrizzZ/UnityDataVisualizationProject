using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerControlPanel : MonoBehaviour
{

    public GameObject SingleControlModulePrefab;
    public GameObject ControlModulesArrayUI;
    public List<GameObject> ControlModulesArray;




    void Start()
    {
        
    }


    void Update()
    {
        
    }

    public void AddSingleModuleToArray(Tower newTower)
    {
        // return if cant find canvas
        if (GameObject.FindGameObjectWithTag("Canvas").GetComponent<Canvas>() == null) return;
        
        // create new single control module
        var newTowerControlModule = Instantiate(SingleControlModulePrefab);

        // set tower controller 
        newTowerControlModule.GetComponent<SingleControlModule>().tower = newTower;

        // add to array
        ControlModulesArray.Add(newTowerControlModule);




        // append to canvas
        newTowerControlModule.transform.SetParent(ControlModulesArrayUI.transform, false);



    }




}
