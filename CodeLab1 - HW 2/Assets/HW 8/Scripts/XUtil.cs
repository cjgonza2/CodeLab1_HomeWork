using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XUtil : MonoBehaviour
{
    public float amplitude;
    public float frequency;

    // Update is called once per frame
    void Update()
    {
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;
        float cos = Mathf.Cos(Time.time * frequency) * amplitude;

        transform.position = new Vector3(x + cos, y, z);
    }
}
