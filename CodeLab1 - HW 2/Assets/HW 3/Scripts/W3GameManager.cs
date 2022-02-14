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
    public Text highRoundText; //creates a text field to display hi

    #region Donkey Health
    public Text donkeyHP; //creates text field for displaying Donkey HP.
    public static int healthValue; //real value of donkey HP.
    #endregion

    #region Timer
    public Text timerText; //creates text field for displaying timer text. 
    float timer; //creates a value for the timer
    float f; //creates a value to use for rounding up the timer. 
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        healthValue = 50; //sets the healthvalue to 50.
        timer = 50; //sets the timer value to 50.
        Debug.Log("I'm the game Manager and the player pref is " + PlayerPrefs.GetInt(W3PlayerPref.SAVE_POINT_KEY));
    }

    // Update is called once per frame
    void Update()
    {
        donkeyHP.text = ("HP:" + healthValue);
        timerText.text = "Time Remaining: " + f;
        //highRoundText.text = ("Highest Round: " + PlayerPrefs.GetInt(W3PlayerPref.SAVE_POINT_KEY));

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
            W3Player.roundTag++;
            
        }
        #endregion

        #region Round Two
        if (W3Player.punchCount >= 50 && W3Player.punchCount < 150) //if punchcount vlue is betwen 50 and 150
        {
            roundText.text = "Round 2!"; //print message.
        }
        if(W3Player.punchCount == 150)  // if punchcount equals 150
        {
            Invoke("RoundThreeDonkey", 0); //call round three function.
            W3Player.roundTag++;
        }
        #endregion

        #region Round Three
        if (W3Player.punchCount >= 150 && W3Player.punchCount < 300) //if punchcount value is between 150 and 300, 
        {
            roundText.text = "Round 3!"; //print message.
        }
        if(W3Player.punchCount == 300)  //if punchcount equals 300,
        {
            Invoke("RoundFourDonkey",0); // calls round four function.
            W3Player.roundTag++;
        }
        #endregion

        #region Final Round
        if (W3Player.punchCount >= 300 && W3Player.punchCount < 550) //if punchcount value is between 300 and 550,
        {
            roundText.text = "Final Round!"; //print message. 
        }
        if(W3Player.punchCount == 550)  //if punchcount equals 550, 
        {
            Invoke("EndGame", 0f);// calls end game funciton. 
        }
        if (timer <= 0) //if timer reaches 0
        {
            Invoke("EndGame", 0f); //ends the game.
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

    public void StartGame()
    {
        SceneManager.LoadScene("GameScreen"); //loads game scene when function is ran.
        Invoke("GameSetup", 0.5f);
    }
    public void GameSetup()
    {
        //after game scene is loaded, GM finds and attaches proper text components.
        timerText = GameObject.Find("Timer").GetComponent<Text>();
        donkeyHP = GameObject.Find("Donkey Health").GetComponent<Text>();
        roundText = GameObject.Find("Round Text").GetComponent<Text>(); 
    }

    public void EndGame()
    {
        SceneManager.LoadScene("W3EndScene"); //loads final scene
        Destroy(this); //destroys gamemanager.
    }
}
