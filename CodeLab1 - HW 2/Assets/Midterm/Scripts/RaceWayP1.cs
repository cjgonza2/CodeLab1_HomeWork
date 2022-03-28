using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceWayP1 : RaceWaySphereController
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Void"))
        {
            gameObject.transform.position = new Vector3(-18, 2.6f, -6);
            myBody.velocity = Vector3.zero;
            myBody.angularVelocity = Vector3.zero;
        }

        if (other.gameObject.CompareTag("Race End 1"))
        {
            SceneManager.LoadScene("Midterm EndScene 1");
        } 
    }

}
