using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    public GameObject Player; //creates an assignable gameobject of the player for the camera to follow. 
    public float cameraHeight; //value to determine how far camera is from player object. 

    private static CameraMove instance; //creates a private assignable instance
    private static CameraMove GetInstance() //returns this script/Object's instance as the primary instance.
    {
        return instance;
    }

    #region Singleton
    private void Awake()
    {
        if(instance != null && instance != this)
        {
            Destroy(this);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
    #endregion

    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = Player.transform.position; //creates a new vector 3 based on the player object's transform position. 
        pos.y = cameraHeight; //sets the vector 3's y position equal to cameraheight value. 
        transform.position = pos;   //sets the transform equal to vector 3. 
    }
}
