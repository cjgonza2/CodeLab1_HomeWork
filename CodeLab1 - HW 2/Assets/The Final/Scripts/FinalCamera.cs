using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalCamera : MonoBehaviour
{

    public GameObject player;
    public float cameraHeight;
    public float cameraDistance;

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = new Vector3(
            player.transform.position.x,
            player.transform.position.y + cameraHeight,
            player.transform.position.z - cameraDistance);

        transform.position = pos;
    }
}
