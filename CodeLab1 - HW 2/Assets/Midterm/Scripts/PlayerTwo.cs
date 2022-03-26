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
}
