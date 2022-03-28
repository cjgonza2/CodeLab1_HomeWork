using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereControlls : MonoBehaviour
{
    public float ballSpeed = 10; //sets float value for the ball's speed. 
    
    [HideInInspector]
    public Rigidbody myBody; //creates a rigidbody reference. 
    [HideInInspector]
    public float playerXMove; //flaot value for ball's x movement to use in movement vector3
    [HideInInspector]
    public float playerZMove; //float value for ball's z movement to use in movement vector3

    public Material baseColor;
    public Material powerUpColor;

    public static bool powerUpOn;
    public int lifePoints = 3;

    public string playerName;
    public Text Health;


    //float playerTwoXMove;
    //float playerTwoZMove;
    
    // Start is called before the first frame update
    protected virtual void Start()
    {
        myBody = GetComponent<Rigidbody>(); //assigns rigidbody component. 
        powerUpOn = false;
    }

    protected virtual void FixedUpdate()
    {
        //Debug.Log(ballSpeed);

        PlayerControls();

        Health.text = playerName + " HP: " + lifePoints;
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

    protected virtual void OnTriggerEnter(Collider other)
    {
        powerUpOn = true;
        PowerUp();
    }

    protected virtual void PowerUp()
    {
        gameObject.GetComponent<Renderer>().material = powerUpColor;
        gameObject.tag = "Powered Up";
        Invoke("PowerDown", 5f);
    }

    protected virtual void PowerDown()
    {
        powerUpOn = false;
        gameObject.GetComponent<Renderer>().material = baseColor;
        gameObject.tag = "Player";
        Debug.Log("powering down");

    }
}
