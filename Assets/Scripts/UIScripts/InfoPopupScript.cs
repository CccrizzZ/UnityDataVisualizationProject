using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InfoPopupScript : MonoBehaviour
{    
    
    
    public Text b_name;
    public Text b_info;
    public Text b_consumption;



    public void SetName(string name)
    {
        b_name.text = name;
    }

    public void SetInfo(string info)
    {
        b_info.text = info;
    }

    public void setConsumption(int consump)
    {
        b_consumption.text = consump.ToString();
    }


}
