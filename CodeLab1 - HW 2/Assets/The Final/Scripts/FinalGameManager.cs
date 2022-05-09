using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalGameManager : MonoBehaviour
{

    static FinalGameManager instance;
    static FinalGameManager GetInstance()
    {
        return instance;
    }

    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void LoadScene(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }
}
