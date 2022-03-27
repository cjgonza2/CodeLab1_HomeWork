using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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


    string currentScene = "";
    
    // Start is called before the first frame update
    void Awake()
    {

        Debug.Log("wakey wakey");

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

        //currentScene = SceneManager.GetActiveScene().name;
        
        //if(LevelName == "JustABox.txt")
        //{
        //    Debug.Log(LevelName);
        //    Invoke("LoadLevel", 0.5f);
        //}
    
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ////Debug.Log(currentScene);
        //if (currentScene == "JustABox.txt")
        //{
        //    LoadLevel();

        //    Invoke("ResetLevel", 0f);
        //}

    }

    //public void SceneChanger(string Level)
    //{
    //    SceneManager.LoadScene(Level);
    //}

    public void LoadJustABox()
    {
        SceneManager.LoadScene("Game Scene");
        currentScene = "JustABox.txt";
        LevelName = currentScene;
        Invoke("LoadLevel", 0.05f);
    }

    void ResetLevel()
    {
        LevelName = "";
    }
}
