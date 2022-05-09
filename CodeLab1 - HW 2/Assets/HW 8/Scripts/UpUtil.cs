using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpUtil : MonoBehaviour
{
    //creates two variables that determines the height and speed of the Cosine wave. 
    public float amplitude;
    public float frequency;

    float timer = 0;


    // Update is called once per frame
    void FixedUpdate()
    {

        timer += Time.deltaTime * frequency;

        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        float sin = Mathf.Sin(timer) * amplitude;

        //sets the transform position of object to the x y and z variable while adding the cosine calculation to the x value
        //causing it to move back and forth.
        transform.position = new Vector3(x, y + sin, z);


        Debug.Log(sin);
    }
}
