using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : SphereControlls
{

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Powered Up"))
        {
            
            if(GameObject.Find("GameManager").GetComponent<MidtermGameManager>().currentScene == "KingHill.txt")
            {
                gameObject.transform.position = new Vector3(-17, 0.6f, 18);
                myBody.velocity = Vector3.zero;
                myBody.angularVelocity = Vector3.zero;
                lifePoints--;
                Debug.Log("hill life loss");
            }
            else
            {
                gameObject.transform.position = new Vector3(-18, 0.6f, 12);
                myBody.velocity = Vector3.zero;
                myBody.angularVelocity = Vector3.zero;
                lifePoints--;
            }
            

        }
    }

}
