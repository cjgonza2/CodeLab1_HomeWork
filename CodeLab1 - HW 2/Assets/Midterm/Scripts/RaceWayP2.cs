using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceWayP2 : RaceWaySphereController
{
    /// <summary>
    /// overrides the inherited player control funciton to change the getaxisraw input. 
    /// </summary>
    protected override void PlayerControls()
    {
        playerXMove = Input.GetAxisRaw("Arrow Horizontal");
        playerZMove = Input.GetAxisRaw("Arrow Vertical");

        //creates a vector 3 that changes based on the the axis inputs of the player.
        Vector3 playerMove = new Vector3(playerXMove, 0.0f, playerZMove);
        //adds force to the rigidbody by a factor of the vector 3 times ballspeed. 
        myBody.AddForce(playerMove * ballSpeed);

        //Why do we use GetAxisRaw instead of GetAxis?
        //Since we're not using a controller, we don't need all the values that getaxis returns, 
        //we just need the -1, 0, and 1.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Void")) //if the tag of the trigger is void:
        {
            gameObject.transform.position = new Vector3(38, 2.6f, -6); //resets the transform posiiton.
            myBody.velocity = Vector3.zero; //sets velocity to zero
            myBody.angularVelocity = Vector3.zero; //sets angular velocity to zero. 
        }

        if (other.gameObject.CompareTag("Race End 2")) //if the tag is the race end 2 tag:
        {
            SceneManager.LoadScene("Midterm EndScene 2"); //loads the end Scene 2.
        }
    }
}
