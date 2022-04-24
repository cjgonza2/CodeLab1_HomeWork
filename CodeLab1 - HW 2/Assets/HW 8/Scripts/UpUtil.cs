using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpUtil : MonoBehaviour
{
    public float amplitude;
    public float frequency;


    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        float sin = Mathf.Sin(Time.time * frequency) * amplitude;

        transform.position = new Vector3(x, y + sin, z);
    }
}
