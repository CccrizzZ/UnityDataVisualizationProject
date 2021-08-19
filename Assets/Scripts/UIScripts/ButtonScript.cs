using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonScript : MonoBehaviour
{

    public void PopupCloseButton()
    {
        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScript>().ResetPosition();
            
        }

        
        Destroy(gameObject);

    }



}
