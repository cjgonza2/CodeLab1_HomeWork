using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HW7PlayerController : MonoBehaviour
{

    public CharacterController controller;

    public float moveSpeed = 6f;

    void Update()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 playerDircetion = new Vector3(horizontal, 0f, vertical).normalized;

        if (playerDircetion.magnitude >= 0.1f) //checks if the player is moving in any direction. 
        {
            controller.Move(playerDircetion * moveSpeed * Time.deltaTime);
        }
    }

}
