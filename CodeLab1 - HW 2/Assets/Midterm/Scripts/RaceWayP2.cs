using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RaceWayP2 : RaceWaySphereController
{
    protected override void PlayerControls()
    {
        playerXMove = Input.GetAxisRaw("Arrow Horizontal");
        playerZMove = Input.GetAxisRaw("Arrow Vertical");

        Vector3 playerMove = new Vector3(playerXMove, 0.0f, playerZMove);
        myBody.AddForce(playerMove * ballSpeed);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Void"))
        {
            gameObject.transform.position = new Vector3(38, 2.6f, -6);
            myBody.velocity = Vector3.zero;
            myBody.angularVelocity = Vector3.zero;
        }

        if (other.gameObject.CompareTag("Race End 2"))
        {
            SceneManager.LoadScene("Midterm EndScene 2");
        }
    }
}
