using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW7PlayerController : MonoBehaviour
{

    public CharacterController controller;

    public float moveSpeed = 6f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal"); //creates a horizontal float value based on the Axis raw Value
        float vertical = Input.GetAxisRaw("Vertical");  //creates a vertical float value based on axis raw value. 
        Vector3 playerDircetion = new Vector3(horizontal, 0f, vertical).normalized; //creates a vector 3 for the  direction player is going and normalizes it. Normalized because we don't need to know the specific value of the direciton, we just need the direction.

        if (playerDircetion.magnitude >= 0.1f) //checks if the player is moving in any direction. 
        {
            controller.Move(playerDircetion * moveSpeed * Time.deltaTime); //moves the character controller based on the vector 3 times movespeed and in relation to delta time. 
        }
    }

}
