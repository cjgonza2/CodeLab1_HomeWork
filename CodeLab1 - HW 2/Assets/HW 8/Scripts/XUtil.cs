using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XUtil : MonoBehaviour
{
    //creates two variables that determines the height and speed of the Cosine wave. 
    public float amplitude;
    public float frequency;
    
    //originally tried just using update for this but for somereason it was causing variable movement between platforms.
    //fixed update seems to be a solution. 
    void FixedUpdate()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        float cos = Mathf.Cos(Time.time * frequency) * amplitude;

        //sets the transform position of object to the x y and z variable while adding the cosine calculation to the x value
        //causing it to move back and forth. 
        transform.position = new Vector3(x + cos, y, z);
    }
}
