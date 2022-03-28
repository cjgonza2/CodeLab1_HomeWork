using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : SphereControlls
{
    protected override void PlayerControls()
    {
        playerXMove = Input.GetAxis("Arrow Horizontal");
        playerZMove = Input.GetAxis("Arrow Vertical");

        Vector3 playerMove = new Vector3(playerXMove, 0.0f, playerZMove);
        myBody.AddForce(playerMove * ballSpeed);
    }

    protected override void PowerUp()
    {
        gameObject.GetComponent<Renderer>().material = powerUpColor;
        gameObject.tag = "Powered Up 2";
        Invoke("PowerDown", 5f);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Powered Up"))
        {
            gameObject.transform.position = new Vector3(-6, 0.6f, 12);
            myBody.velocity = Vector3.zero;
            myBody.angularVelocity = Vector3.zero;
            lifePoints--;
            Debug.Log(lifePoints);
        }
    }
}
