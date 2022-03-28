using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceWayP1 : RaceWaySphereController
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Void")) //if the trigger tag is void:
        {
            gameObject.transform.position = new Vector3(-18, 2.6f, -6); //resets the transform posiiton.
            myBody.velocity = Vector3.zero; //sets velocity to zero.
            myBody.angularVelocity = Vector3.zero; //sets angular velocity to zero. 
        }

        if (other.gameObject.CompareTag("Race End 1"))  //if the trigger tag is end race 1:
        {
            SceneManager.LoadScene("Midterm EndScene 1"); //loads the end  scene 1. 
        } 
    }

}
