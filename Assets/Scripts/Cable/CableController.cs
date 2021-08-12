using UnityEngine;

public class CableController : MonoBehaviour
{
    public Material cable1mat;
    public Material cable2mat;
    public Material cableOffmat;


    public GameObject cable1;
    public GameObject cable2;



    Material cable1PrevMat;
    Material cable2PrevMat;




    Color cable1charge;
    Color cable2charge;


    bool cable1_On;
    bool cable2_On;



    void Start() 
    {
        cable1_On = true;
        cable2_On = true;
    }


    void Update() 
    {
        
        if (Input.GetKeyDown(KeyCode.Q))
        {
            SetPositive(cable1mat);
        }


        // if (Input.GetKeyDown(KeyCode.W))
        // {
        //     if (isOn(cable1mat) && isOn(cable2mat))
        //     {
        //         // save cables charge
        //         cable1charge = cable1mat.GetColor("_Color");
        //         cable2charge = cable2mat.GetColor("_Color");


        //         // set cables color to white
        //         TurnOff(cable1mat);
        //         cable1mat.SetColor("_Color", Color.gray);

        //         TurnOff(cable2mat);
        //         cable2mat.SetColor("_Color", Color.gray);


        //     }
        //     else
        //     {
        //         TurnOn(cable1mat);
        //         cable1mat.SetColor("_Color", cable1charge);

        //         TurnOn(cable2mat);
        //         cable2mat.SetColor("_Color", cable2charge);

        //     }

        // }
        

        // else if (Input.GetKeyDown(KeyCode.E))
        // {
        //     SetNegative(cable1mat);
        // }
        
        // if (Input.GetKeyDown(KeyCode.A))
        // {
        //     SetPositive(cable2mat);
            
        // }

        // else if (Input.GetKeyDown(KeyCode.D))
        // {
        //     SetNegative(cable2mat);
        // }

    }


    void SetPositive(Material mat)
    {
        if (!isOn(mat))return;

        mat.SetColor("_Color", Color.red);
        mat.SetFloat("_Direction", 1f);

        IsPositive_bool(mat);

    }


    void SetNegative(Material mat)
    {
        if (!isOn(mat))return;

        mat.SetColor("_Color", Color.blue);
        mat.SetFloat("_Direction", -1f);

        IsPositive_bool(mat);
    }



    void TurnOn(Material mat)
    {
        mat.SetFloat("_isOn", 1f);
    }


    void TurnOff(Material mat)
    {
        mat.SetFloat("_isOn", 0f);
    }




    public bool IsPositive_bool(Material mat)
    {
        if (mat.GetFloat("_Direction") > 0)
        {
            print("Positive");
            return true;
        }
        else if(mat.GetFloat("_Direction") < 0)
        {
            print("Negative");
            return false;
        }


        print("ERROR");
        return false;
    }


    public float IsPositive_float(Material mat) 
    {
        return mat.GetFloat("_Direction");
    }


    bool isOn(Material mat)
    {
        if (mat.GetFloat("_isOn") > 0)
        {
            // print("On");
            return true;
        }
        else if(mat.GetFloat("_isOn") == 0)
        {
            // print("Off");
            return false;
        }


        print("ERROR");
        return false;
    }





    public bool isBothCableOn()
    {
        return cable1_On && cable2_On;
    }


    public void TurnOnBothCable()
    {
        if(isBothCableOn()) return;


        // print("Turning On Both Cable");

        // TurnOn(cable1mat);
        // TurnOn(cable2mat);


        // set to off material
        cable1.GetComponent<Renderer>().material = cable1mat;
        cable2.GetComponent<Renderer>().material = cable2mat;


        cable1_On = true;
        cable2_On = true;

    }


    public void TurnOffBothCable()
    {
        if(!isBothCableOn()) return;
        // print("Turning Off Both Cable");

        // TurnOff(cable1mat);
        // TurnOff(cable2mat);


        // save both cables material
        cable1PrevMat = cable1.GetComponent<Renderer>().material;
        cable2PrevMat = cable2.GetComponent<Renderer>().material;


        // set to off material
        cable1.GetComponent<Renderer>().material = cableOffmat;
        cable2.GetComponent<Renderer>().material = cableOffmat;



        // set bool
        cable1_On = false;
        cable2_On = false;

    }

}
