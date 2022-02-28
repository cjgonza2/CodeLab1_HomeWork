using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBall : MonoBehaviour
{
    public GameObject myCamera;

    private static PlayerBall instance; //creates a private an assig
    private static PlayerBall GetInstance() //returns this script/Object's instance as the primary instance.
    {
        return instance;
    }

    #region Singleton
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

    public ASCIILevelLoader loader; //creates a public assignable reference to the ASCII Level Loader Script. 

    public int moveSpeed; //creates value for the player's move speed. 
    public static bool levelOne; //sets a bool to check if level One is complete. 

    // Start is called before the first frame update
    void Start()
    {
        levelOne = false; 
    }

    // Update is called once per frame
    void Update()
    {
        //for each given key pressed, calls the move funciton.
        Move(KeyCode.W, 0, moveSpeed);
        Move(KeyCode.S, 0, -moveSpeed);
        Move(KeyCode.A, -moveSpeed, 0);
        Move(KeyCode.D, moveSpeed, 0);
    }

    void Move(KeyCode key, float xMove, float zMove)
    {
        if (Input.GetKey(key)) //for a given input, applies velocity to the object rigidbody. 
        {
            GetComponent<Rigidbody>().velocity = new Vector3(xMove, 0, zMove);
        }
    }

    public void OnTriggerEnter(Collider other) //when colliding with goal object. 
    {
        if (levelOne != true) //if levelone bool is not true, sets it true, changes level loader filename and change's the level. 
        {
            levelOne = true;
            loader.fileName = "Level 2.txt";
            Debug.Log("filename changed");
            loader.ChangeLevel();
        }
        else //if its' already set to true, goes to end screen. 
        {
            loader.EndGame();
            Destroy(myCamera);
            Destroy(this);
        }
    }
}


