using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class W3GameManager : MonoBehaviour
{

    #region GameManager Setup
    private static W3GameManager instance; //creates an instance variable for the game manager script.
    public static W3GameManager GetInstance() //returns the GM's instance. 
    {
        return instance;
    }
    //checks if there are multiple GM instances and destroys them. 
    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    public Text roundText; //creates a text field to dipslay what round it is. 

    #region Donkey Health
    public Text donkeyHP; //creates text field for displaying Donkey HP.
    public static int healthValue; //real value of donkey HP.
    #endregion

    #region Timer
    public Text timerText;
    float timer;
    float f;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        healthValue = 50;
        timer = 30;
        PlayerPrefs.GetInt(W3PlayerPref.SAVE_POINT_KEY);
        Debug.Log("I'm the game Manager and the player pref is " + PlayerPrefs.GetInt(W3PlayerPref.SAVE_POINT_KEY));
    }

    // Update is called once per frame
    void Update()
    {
        donkeyHP.text = ("HP:" + healthValue);
        timerText.text = "Time Remaining: " + f;

        if(timer > 0) //if timer value is greater than 0,
        {
            timer -= Time.deltaTime; //timer value with count down in relation to time.deltatime.
        }
        f = Mathf.Round((timer * 10.0f) * 0.1f); //takes the timer value and rounds it to whole number. 

        #region Round One
        if (W3Player.punchCount < 50) //if punch count is below 50
        {
            roundText.text = "Round 1!"; //print message. 
        }
        if(W3Player.punchCount == 50) //if punch count equals.
        {
            Invoke("RoundTwoDonkey", 0); //calls round two function.
        }
        #endregion

        #region Round Two
        if (W3Player.punchCount >= 50 && W3Player.punchCount < 100) //if punchcount vlue is betwen 50 and 100
        {
            roundText.text = "Round 2!"; //print message.
        }
        if(W3Player.punchCount == 100)  // if punchcount equals 100
        {
            Invoke("RoundThreeDonkey", 0); //call round three function.
        }
        #endregion

        #region Round Three
        if (W3Player.punchCount >= 100 && W3Player.punchCount < 150)
        {
            roundText.text = "Round 3!";
        }
        if(W3Player.punchCount == 150)
        {
            Invoke("RoundFourDonkey",0);
        }
        #endregion

        #region Final Round
        if (W3Player.punchCount >= 150 && W3Player.punchCount < 250)
        {
            roundText.text = "Final Round!";
        }
        if(W3Player.punchCount == 250)
        {
            Debug.Log("You finished!");
        }
        #endregion
    }

    public void RoundTwoDonkey()
    {
        healthValue = 100;
    }
    public void RoundThreeDonkey()
    {
        healthValue = 150;
    }
    public void RoundFourDonkey()
    {
        healthValue = 250;
    }
}
