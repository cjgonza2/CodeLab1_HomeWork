using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class W3Player : MonoBehaviour
{
    public static int roundTag;

    public static int punchCount;

    // Start is called before the first frame update
    void Start()
    {
        roundTag = 0; //sets roundtag to 0
        punchCount = 0; //sets punchcount to 0.
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            punchCount++;
            W3GameManager.healthValue--;
        }
        //Debug.Log(roundTag);
    }
}
