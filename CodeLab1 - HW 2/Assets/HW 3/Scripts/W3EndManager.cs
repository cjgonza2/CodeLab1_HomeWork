using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class W3EndManager : MonoBehaviour
{

    public Text highscoreText;
    public Text punchCountText;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        highscoreText.text = ("Highest Round: " + PlayerPrefs.GetInt(W3PlayerPref.SAVE_POINT_KEY));
        punchCountText.text = ("Punches This Round: " + PlayerPrefs.GetInt(W3PlayerPref.PUNCH_POINT_KEY));
    }
}
