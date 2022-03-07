using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW5PlayerBehavior : MonoBehaviour
{

    //this ensures that the instance of the player isn't duplicated.
    #region Singleton Loop
    private static HW5PlayerBehavior instance;

    public static HW5PlayerBehavior FindInstance()
    {
        return instance;
    }

    void Awake()
    {
        if(instance != null && instance != null)
        {
            Destroy(this);
        }else if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(this);
        }
    }
    #endregion;

    public int playerDamage = 1;

    HW5GameManager myManager; //assigns the gameManager script 
    
    // Start is called before the first frame update
    void Start()
    {
        myManager = HW5GameManager.FindInstance();
    }

    // Update is called once per frame
    void Update()
    {
        if (myManager.currentState == HW5GameManager.State.Battle)
        {
            Punch(KeyCode.Space);
        }
        //Debug.Log(myManager.currentEnemyHP);
        Debug.Log(myManager.currentPlayerHP);
    }

    void Punch(KeyCode key)
    {
        if (Input.GetKeyUp((key)))
        {
            myManager.enemyHPvalue -= playerDamage;
            myManager.currentEnemyHP = myManager.enemyHPvalue;
            Debug.Log("You pressed space");
        }
    }
}
