using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOne : SphereControlls
{

    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Powered Up"))
        {
            gameObject.transform.position = new Vector3(-18, 0.6f, 12);
            lifePoints--;
        }
    }

}
