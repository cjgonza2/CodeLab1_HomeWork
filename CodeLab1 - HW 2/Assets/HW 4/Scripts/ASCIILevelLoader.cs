using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class ASCIILevelLoader : MonoBehaviour
{

    public string fileName; 


    // Start is called before the first frame update
    void Start()
    {
        StreamReader reader = new StreamReader(fileName); //initiate streamreader and looks for file that matches the filename string.
        string fileContent = reader.ReadToEnd(); //creates a string based on content of file.
        reader.Close(); //closes streamreader.

        char[] newLineChar = { '\n' };

        string[] level = fileContent.Split(newLineChar); //creates string array that split's each entry by the defined delimiter.




    }

    void MakeRow(string stringRow, float z)
    {
        char[] rowArray = stringRow.ToCharArray();
        for(int x = 0; x < stringRow.Length; x++)
        {
            char c = rowArray[x];
        }
    }
}
