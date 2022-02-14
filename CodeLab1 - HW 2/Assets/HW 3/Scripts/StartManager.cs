using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartManager : MonoBehaviour
{

    public Text highscoreText;
    public Text lastRoundText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highscoreText.text = ("Highest Round: " + PlayerPrefs.GetInt(W3PlayerPref.SAVE_POINT_KEY));
        lastRoundText.text = ("Last Round's Punches: " + PlayerPrefs.GetInt(W3PlayerPref.PUNCH_POINT_KEY));
    }
}
