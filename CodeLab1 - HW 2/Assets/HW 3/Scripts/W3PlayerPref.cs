using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W3PlayerPref : MonoBehaviour
{
    public const string SAVE_POINT_KEY = "savePointKey";

    public int SavePoint;
    
    // Start is called before the first frame update
    void Start()
    {
        SavePoint = PlayerPrefs.GetInt(SAVE_POINT_KEY);
        //if(SavePoint == 0)
        Debug.Log(PlayerPrefs.GetInt(SAVE_POINT_KEY));
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(SavePoint);
        ///
        #region Save Checks
        //These checks directly correspond to the player script save tag value. Depending on what that save tag is,
        //the playpref is automatically updated.
        if (W3Player.roundTag == 1)
        {
            PlayerPrefs.SetInt(SAVE_POINT_KEY, 1);
            Debug.Log("Checkpoint: " + PlayerPrefs.GetInt(SAVE_POINT_KEY));
        }
        if (W3Player.roundTag == 2)
        {
            PlayerPrefs.SetInt(SAVE_POINT_KEY, 2);
            Debug.Log("Checkpoint:" + PlayerPrefs.GetInt(SAVE_POINT_KEY));
        }
        if(W3Player.roundTag == 3)
        {
            PlayerPrefs.SetInt(SAVE_POINT_KEY, 3);
        }
        if(W3Player.roundTag == 4)
        {
            PlayerPrefs.SetInt(SAVE_POINT_KEY, 4);
        }
        if(W3Player.roundTag == 5)
        {
            PlayerPrefs.SetInt(SAVE_POINT_KEY, 5);
        }
        if (Input.GetKeyUp(KeyCode.Delete))
        {
            PlayerPrefs.SetInt(SAVE_POINT_KEY, 0);
            Debug.Log("You reset the save counter!");
        }
        #endregion
    }
}
