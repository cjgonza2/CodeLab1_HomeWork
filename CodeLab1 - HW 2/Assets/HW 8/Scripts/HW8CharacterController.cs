using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HW8CharacterController : MonoBehaviour
{

    public CharacterController playerController;

    public float moveSpeed;
    public float jumpSpeed;

    Vector3 spawnPos;
    float spawnX;
    float spawnY;
    float spawnZ;

   //[HideInInspector]
    public float playerGravity;
    

    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<CharacterController>();

        spawnX = transform.position.x;
        spawnY = transform.position.y;
        spawnZ = transform.position.z;

        spawnPos = new Vector3(spawnX, spawnY, spawnZ); //sets a spawn position and saves it in a vector3.
       
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(spawnPos);
        playerGravity += (Physics.gravity.y * Time.deltaTime);
        //what is this doing? It's using Unity's built in Gravity and multiplying it times delta time.
        //in this case it's applying the base gravity value of -9.8 to the y. 

        if (playerController.isGrounded) // .isGrounded is a built in feature of character controllers that checks to see if it's touching ground. 
        {
            playerGravity = -0.5f; //for some reason, even though the character controller is ground, the playergravity value
                                   //will continue to decrease and it messes with the physics. Set the value while it's
                                   //grounded prevents that from happening.

            if (Input.GetKeyDown(KeyCode.Space)) //if space is pressed,
            {
                playerGravity = jumpSpeed; //player gravity is set to jumpspeed.
            }
        }
        
        MovePlayer();
    }

    void MovePlayer()
    {
        float horizontalDir = Input.GetAxisRaw("Horizontal"); //creates a float value for horizontal direction.
        float verticalDir = Input.GetAxisRaw("Vertical");     //creates a float value for verticla direction.
        Vector3 playerDirection = new Vector3(horizontalDir, 0f, verticalDir).normalized; //normalizes the vector 3 since we only need to know the direction and not the specific value.
        playerDirection.y = playerGravity; //sets the y vector3 value to the gravity value. 

        if (playerDirection.magnitude >= 0.1f) //maginitude is the direciton, so as long as the object has a direciton,
        {
            playerController.Move(playerDirection * moveSpeed * Time.deltaTime); //the player controller will move. 
        }
    }

    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Reset Position")) //compares the tag of the trigger and if it's reset position
                                                          //than it runs resets the position. 
        {
            //Debug.Log("time to reset position");
            
            //for some reason while the character controller is enabled, You can't reset the 
            //transform position. A work around is disabling the character controller and then 
            //resetting its position and then reenabling it. That's what the below 3 lines do.
            playerController.enabled = false;
            playerController.transform.position = spawnPos; 
            playerController.enabled = true;            
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("HW 8 End Scene");
        }
    }
}
