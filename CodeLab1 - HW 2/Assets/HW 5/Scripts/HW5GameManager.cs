using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HW5GameManager : MonoBehaviour
{

    //creates singleton loop that ensures multiple instances of the gamemanger are not created. 
    #region Singleton
    private static HW5GameManager instance;

    public static HW5GameManager FindInstance()
    {
        return instance;
    }
    void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }else if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion

    public enum State //creates state machine with 5 designated states
    {
        RoundStart,
        Battle,
        RoundEnd,
        NewRound,
        EndGame
    }

    public GameObject player; //creates gameobject reference to player object. 
    public GameObject enemy; //creates gameobject reference to enemy object. 

    public Text timerText; //creates text reference for timer. 

    public int playerHPvalue = 100; //sets an hp value for the player. 
    public int enemyHPvalue = 100; //sets an hp value for the enemy.
    public int currentPlayerHP; //creates a variable for tracking the current player hp.
    public int currentEnemyHP;  //creates a variable for tracking the current enemy hp.
    public int enemyDamage = 20; //sets a damage value for the enemy's attack. 
    
    public float timer; //creates a float value for timer. 
    public float roundedTimer; //creates float variable for rounding up the timer variable. 


    public Slider playerHP; //creates slider reference for the playerHP slider.
    public Slider enemyHP; //creates slider reference for the enemyHP slider. 

    public State currentState; //creates a state variable that keeps track of the current state. 

    // Start is called before the first frame update
    void Start()
    {
        timerText.text = " "; //sets the timer text to null. 
        currentEnemyHP = enemyHPvalue; //sets the current enemyhp variable equal to enemy's hp.
        currentPlayerHP = playerHPvalue; //sets the current playerhp variable to the player's hp
        //Debug.Log(currentState);

        TransitionState(State.RoundStart); //transitions to the next state.
    }

    void Update()
    {
        Debug.Log(currentState);
        playerHP.value = playerHPvalue; //sets the playerhp slider value to that of the player's current value.
        enemyHP.value = enemyHPvalue; //sets the enemyhp slider value to that of the enemy's current value. 

        if(currentState == State.Battle) //if the current state is the battle state,
        {
            if(timer > 0) //and the timer value is greater than 0, 
            {
                timer -= Time.deltaTime; //timer value is ticked down based on delta time. 
            }
            roundedTimer = Mathf.Round((timer * 10.0f) * 0.1f); //rounds timer variable to a whole number. 
            timerText.text = ("Time Remaining: " + roundedTimer); //sets the text to display the current timer. 
            if(timer <= 0) //if timer value is less than 0, 
            {
                TransitionState(State.RoundEnd); //transitions to next state. 
            }
        }
        if(currentState == State.NewRound)
        {
            if(timer > 0)
            {
                timer -= Time.deltaTime;
            }
            roundedTimer = Mathf.Round((timer * 10.0f) * 0.1f);
            timerText.text = ("Next round in: " + roundedTimer);
            if(timer <= 0 )
            {
                TransitionState(State.Battle);
            }
        }
        
        
        if(currentEnemyHP == 0 || currentPlayerHP == 0) //if either the player's or enemy's hp equals 0, 
        {
            TransitionState(State.EndGame); //transitions to end game state. 
        }
    }

    public void TransitionState(State newState)
    {
        currentState = newState; //sets the state declared whenever function is called to the current state variable. 
        switch (newState) //switches the state. 
        {
            case State.RoundStart:
                //during roundstart state. 
                //instantiates player object and sets it to position. 
                GameObject playerLoad = Instantiate(player); 
                playerLoad.transform.position = new Vector3(-2, -1, -8);
                //instantiates enemy object and sets it to position. 
                GameObject enemyLoad = Instantiate(enemy);
                enemyLoad.transform.position = new Vector3(2, -1, -6.5f);

                TransitionState(State.Battle); //transitions to next state. 
                break;

            case State.Battle:

                timer = 3; //sets the timer value to 3.

                break;

            case State.RoundEnd:
                if (currentEnemyHP == 0) //if enemy's hp is 0, 
                {
                    TransitionState(State.EndGame); //transitions to endgame state.
                }
                else // if not, 
                {
                    playerHPvalue -= enemyDamage; //subtract enemy damage from player hp value. 
                    currentPlayerHP = playerHPvalue; //sets the player hp to tracking variable. 
                    TransitionState(State.NewRound); //transitions to next state. 
                }
                break;

            case State.NewRound:
                
                timer = 3; //sets timer value to 3.

                break;

            case State.EndGame:
                
                break;
        }
    }
}
