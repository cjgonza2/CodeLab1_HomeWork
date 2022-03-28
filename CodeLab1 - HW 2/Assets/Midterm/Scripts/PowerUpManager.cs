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
