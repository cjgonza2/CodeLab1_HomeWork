using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTwo : SphereControlls
{
    protected override void PlayerControls()
    {
        playerXMove = Input.GetAxisRaw("Arrow Horizontal");
        playerZMove = Input.GetAxisRaw("Arrow Vertical");

        Vector3 playerMove = new Vector3(playerXMove, 0.0f, playerZMove);
        myBody.AddForce(playerMove * ballSpeed);
    }

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Powered Up"))
        {
            if(GameObject.Find("GameManager").GetComponent<MidtermGameManager>().currentScene == "KingHill.txt")
            {
                gameObject.transform.position = new Vector3(-3.1f, 0.5f, 2.3f);
                myBody.velocity = Vector3.zero;
                myBody.angularVelocity = Vector3.zero;
                lifePoints--;
            }
            else
            {
                gameObject.transform.position = new Vector3(-6, 0.6f, 12);
                myBody.velocity = Vector3.zero;
                myBody.angularVelocity = Vector3.zero;
                lifePoints--;
                Debug.Log(lifePoints);
            }
        }
    }
}
