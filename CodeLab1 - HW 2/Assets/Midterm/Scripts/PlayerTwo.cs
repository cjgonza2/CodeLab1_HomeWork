using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : SphereControlls
{
    /// <summary>
    /// overrides the inherited player control funciton to change the getaxisraw input. 
    /// </summary>
    protected override void PlayerControls()
    {
        //sets the x/zMove value the the respective getaxisRaw value. 
        playerXMove = Input.GetAxisRaw("Arrow Horizontal");
        playerZMove = Input.GetAxisRaw("Arrow Vertical");

        //creates a vector 3 that changes based on the the axis inputs of the player.
        Vector3 playerMove = new Vector3(playerXMove, 0.0f, playerZMove);
        //adds force to the rigidbody by a factor of the vector 3 times ballspeed. 
        myBody.AddForce(playerMove * ballSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Powered Up")) //if the collider tag is powered up:
        {
            //and if the gamemanager's currentscene string is kingHill.txt:
            if(GameObject.Find("GameManager").GetComponent<MidtermGameManager>().currentScene == "KingHill.txt")
            {
                gameObject.transform.position = new Vector3(-3.1f, 0.5f, 2.3f); //resets transform position.
                myBody.velocity = Vector3.zero; //sets velocity to zero
                myBody.angularVelocity = Vector3.zero; //sets angular velocity to zero. 
                lifePoints--; //subtracts one from the life point value. 
            }
            else
            {
                gameObject.transform.position = new Vector3(-6, 0.6f, 12);
                myBody.velocity = Vector3.zero;
                myBody.angularVelocity = Vector3.zero;
                lifePoints--;
                //Debug.Log(lifePoints);
            }
        }
    }
}
