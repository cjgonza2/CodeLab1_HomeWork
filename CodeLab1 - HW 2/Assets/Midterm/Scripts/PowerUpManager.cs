using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{

    //public GameObject powerUpTop;
    public GameObject powerUpMid;
    //public GameObject powerUpBot;

    float powerUpValue;



    
    
    // Start is called before the first frame update
    void Start()
    {

    }

    void Update()
    {
        //This if statement checks if the powerUpOn bool is active,
        //if it is true, it will deactivate the power up. Otherwise
        //it will be active. 
        if (PlayerOne.powerUpOn || PlayerTwo.powerUpOn == true)
        {
            powerUpMid.SetActive(false);
        }
        else
        {
            powerUpMid.SetActive(true);
        }
    }
}
