using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MidtermGameManager : MidtermLevelLoader
{

    #region GameManagerInstance
    static MidtermGameManager instance;
    static MidtermGameManager GetInstance()
    {
        return instance;
    }
    #endregion

    public string currentScene = "";
    
    // Start is called before the first frame update
    void Awake()
    {

        //Debug.Log("wakey wakey");

        #region Singleton
        //Singleton loop to prevent multiple instance of the GameManager.
        if (instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }

    void Update()
    {
        //if the current scene is equal to either of these two strings. 
        if (currentScene == "JustABox.txt" || currentScene == "KingHill.txt")
        {

            //if player one's lifepoints == 0, loads EndScene 2.
            if (GameObject.Find("Player 1").GetComponent<PlayerOne>().lifePoints == 0)
            {

                Debug.Log("Player 2 wins");
                
                SceneManager.LoadScene("Midterm EndScene 2");
            } 
            //if player 2 lifepoints equals 0, loads endScene 1.
            else if (GameObject.Find("Player 2").GetComponent<PlayerTwo>().lifePoints == 0)
            {

                Debug.Log("Player 1 wins");
                
                SceneManager.LoadScene("Midterm EndScene 1");
            }
        }
    }

    /// <summary>
    /// This funciton when called (by UI button press)
    /// will load the game scene, change the current scene
    /// string to "JustABox.txt" and set that to the 
    /// level loader's string and then call the inherited
    /// load level function.
    /// </summary>
    public void LoadJustABox()
    {
        SceneManager.LoadScene("Game Scene");
        currentScene = "JustABox.txt";
        LevelName = currentScene;
        Invoke("LoadLevel", 0.05f);
    }

    /// <summary>
    /// This funciton when called (by UI button press)
    /// will load the race way scene, change the current scene 
    /// string to "Raceway.txt" and set that to the level  loader's
    /// string and then call the inherited load level function. 
    /// </summary>
    public void LoadRaceWay()
    {
        SceneManager.LoadScene("Race Scene");
        currentScene = "RaceWay.txt";
        LevelName = currentScene;
        Invoke("LoadLevel", 0.05f);
    }


    /// <summary>
    /// This funciton when called (by UI button press)
    /// will load the race way scene, change the current scene 
    /// string to "KingHill.txt" and set that to the level  loader's
    /// string and then call the inherited load level function. 
    /// </summary>
    public void LoadKingHill()
    {
        SceneManager.LoadScene("Hill Scene");
        currentScene = "KingHill.txt";
        LevelName = currentScene;
        Invoke("LoadLevel", 0.05f);
    }
}
