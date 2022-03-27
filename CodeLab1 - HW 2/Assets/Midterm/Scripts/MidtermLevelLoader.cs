using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class MidtermLevelLoader : MonoBehaviour
{

    public string LevelName;
    public float xOffset;
    public float zOffset;

    void Start()
    {
        
    }

    protected virtual void LoadLevel()
    {
        Debug.Log("I've loaded the level");

        StreamReader reader = new StreamReader(LevelName); //initiates SteamReader and looks for a file with coresbonding level name. 
        string fileContent = reader.ReadToEnd(); //creates string based on content of the file. 
        reader.Close(); //closes StreamReader.

        char delimiterChar = '\n'; //creates a character variable that will serve as a delimiter. 

        string[] level = fileContent.Split(delimiterChar); //creates a string array. Will split each string by designated delimiter. 

        for(int i = 0; i < level.Length; i++)
        {
            MakeRow(level[i], -i);
        }
    }

    protected virtual void MakeRow(string stringRow, float z)
    {
        char[] rowArray = stringRow.ToCharArray();
        for(int x = 0; x < stringRow.Length; x++)
        {
            char c = rowArray[x];
            if(c == 'W')
            {
                GameObject WALL = Instantiate(Resources.Load("Wall")) as GameObject;
                WALL.transform.position = new Vector3(
                    x * WALL.transform.localScale.x + xOffset,
                    1,
                    z * WALL.transform.localScale.z + zOffset
                    );
            }
        }
    }
}
