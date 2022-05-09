using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalGameManager : MonoBehaviour
{

    public bool npcFinish;
    public bool playerFinish;
    
    void Start()
    {
        npcFinish = false;
        playerFinish = false;

    }

    // Update is called once per frame
    void Update()
    {
        if (npcFinish == true)
        {
            Debug.Log("the npc finished first");
        }
        if (playerFinish == true)
        {
            Debug.Log("player finished first");
        }
    }
}
