using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.SceneManagement;

public class ASCIILevelLoader : MonoBehaviour
{
    private static ASCIILevelLoader instance; //creates a private assignable instance
    private static ASCIILevelLoader GetInstance() //returns this script/Object's instance as the primary instance.
    {
        return instance;
    }

    private void Awake()
    {
        #region Singleton
        //Singleton loop to prevent multiple instances of the level Loader.
        if (instance != null && instance != this)  //for self: checks the instance, if it's not nothing and not THE gameobject that checking, destroys object. 
        {
            Destroy(this);
        }
        else   //for self: if not the above, asigns this object to the instance. 
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        #endregion
    }


    public string fileName; 
    public float xOffset;
    public float zOffset;


    // Start is called before the first frame update
    void Start()
    {
        LoadLevel(); //calls function
    }
    void LoadLevel() //reads file name and assigns information to be built. 
    {
        StreamReader reader = new StreamReader(fileName); //initiate streamreader and looks for file that matches the filename string.
        string fileContent = reader.ReadToEnd(); //creates a string based on content of file.
        reader.Close(); //closes streamreader.

        char[] newLineChar = { '\n' };  //creates a character array. 

        string[] level = fileContent.Split(newLineChar); //creates string array that split's each entry by the defined delimiter.

        for(int i = 0; i < level.Length; i++) //for loop that checks each entry in the level array and calls MakeRow based on the given parameters. 
        {
            MakeRow(level[i], -i);
        }
    }

    void MakeRow(string stringRow, float z) //builds the level based on the read file.
    {
        
        char[] rowArray = stringRow.ToCharArray(); //sets a character array equal to the the string for each row. 
        for(int x = 0; x < stringRow.Length; x++)
        {
            char c = rowArray[x]; //creates character variable c and sets it equall to the character row array. 
            if(c == 'X') //if the character = X, loads brick object from resources folder. 
            {
                Debug.Log("Make the Brick");
                GameObject BRICK = Instantiate(Resources.Load("Brick")) as GameObject;
                BRICK.transform.position = new Vector3(   //sets the blocks position to it's position in the string and in relation to it's scale and a determined offset. 
                    x * BRICK.transform.localScale.x + xOffset,
                    1,
                    z * BRICK.transform.localScale.z + zOffset
                    );
            }else if(c == 'O') //if the character = O, loads goal object form resources folder. 
            {
                GameObject GOAL = Instantiate(Resources.Load("Goal")) as GameObject;
                GOAL.transform.position = new Vector3(  //sets the blocks position to it's position in the string and in relation to it's scale and a determined offset.
                    x * GOAL.transform.localScale.x + xOffset,
                    1,
                    z * GOAL.transform.localScale.z + zOffset
                    );
            }
        }
    }


    public void ChangeLevel()
    {
        SceneManager.LoadScene("HW 4 - Level 2"); //loads level 2 scene
        Invoke("LoadLevel", 0.1f); //invokes the load level function
    }

    public void EndGame()
    {
        SceneManager.LoadScene("HW 4 - End Scene"); //loads end scene.
    }


}
