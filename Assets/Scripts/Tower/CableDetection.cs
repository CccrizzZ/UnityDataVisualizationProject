using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableDetection : MonoBehaviour
{


    [SerializeField] Tower TowerController;




    void Start()
    {
        // detect all connected cables on start
        Collider[] hitColliders = Physics.OverlapSphere(transform.position, 4.5f);
        foreach (var item in hitColliders)
        {
            // print(item.name);

            //  add all item with tag cable to tower controller's cable array
            if (item.tag == "Cable")
            {
                TowerController.AllCablesArr.Add(item.GetComponent<CableController>());
            }

        }


    }

    


    // update all nearby tower's indicator
    public void UpdateAllNearByTowers()
    {
        Collider[] hitColliders = Physics.OverlapBox(transform.position, new Vector3(200, 10, 200));
        foreach (var item in hitColliders)
        {
            if (item.tag == "Indicator")
            {
                item.GetComponent<TowerIndicator>().UpdateIndicator();
            }
        }
    }
}
