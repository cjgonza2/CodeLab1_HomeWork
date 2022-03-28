using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaceWaySphereController : MonoBehaviour
{
    public float ballSpeed = 10; //sets float value for the ball's speed. 

    [HideInInspector]
    public Rigidbody myBody; //creates a rigidbody reference. 
    [HideInInspector]
    public float playerXMove; //flaot value for ball's x movement to use in movement vector3
    [HideInInspector]
    public float playerZMove; //float value for ball's z movement to use in movement vector3

    protected virtual void Start()
    {
        myBody = GetComponent<Rigidbody>(); //assigns rigidbody component. 
    }

    protected virtual void FixedUpdate()
    {
        PlayerControls();

        //why fixedupdate and no update?
        //because when using addforce, you have to use fixed update. 
    }

    protected virtual void PlayerControls()
    {
        //the value of xMove and zMove is determined by the input axis. 
        //Input getaxis returns a value between -1 and 1
        //if we were using joystick it would return antyhing inbetween based on how far the joystick is pressed.
        //since we're using a keyboard here it's only going to return -1 or 1
        playerXMove = Input.GetAxisRaw("Horizontal");
        playerZMove = Input.GetAxisRaw("Vertical");

        //creates a vector 3 with the assigned x and z ballmove values and
        //adds force to the sphere based on it and in relation to the ball's speed value. 
        Vector3 playerOneMove = new Vector3(playerXMove, 0.0f, playerZMove);
        myBody.AddForce(playerOneMove * ballSpeed);
    }

}
