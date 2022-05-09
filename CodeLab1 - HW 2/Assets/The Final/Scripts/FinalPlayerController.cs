using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinalPlayerController : MonoBehaviour
{
    #region variables
    CharacterController playerController;

    [SerializeField]
    float moveSpeed;
    [SerializeField]
    float jumpSpeed;
    float playerGravity;

    [SerializeField]
    Vector3 spawnPos;
    
    //Vector3 moveInput;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        playerController = gameObject.GetComponent<CharacterController>();
        spawnPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        playerGravity += (Physics.gravity.y * Time.deltaTime);

        MovePlayer();
        PlayerJump();



        //moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

    }

    private void FixedUpdate()
    {
        //GetComponent<Rigidbody>().velocity = moveInput * moveSpeed;

        //Vector3 lookPos = new Vector3(
        //    transform.position.x + GetComponent<Rigidbody>().velocity.x,
        //    transform.position.y,
        //    transform.position.z + GetComponent<Rigidbody>().velocity.z
        //    );
        //transform.LookAt(lookPos);
    }

    #region Player Movement
    void MovePlayer()
    {
        Vector3 playerDirection = new Vector3(
            Input.GetAxis("Horizontal"),
            playerGravity, 
            Input.GetAxisRaw("Vertical")).normalized;

        if(playerDirection.magnitude >= 0.1f)
        {
            playerController.Move(playerDirection * moveSpeed * Time.deltaTime);
        }
    }
    void PlayerJump()
    {
        if (playerController.isGrounded) //checks if character controller is grounded. 
        {
            playerGravity = -0.5f; //if so, will set gravity to -0.5. Doing this prevents the playergravity from decreasing
                                   //infinitely, preventing the character from moving.

            if (Input.GetKeyDown(KeyCode.Space)) //if space is pressed.
            {
                playerGravity = jumpSpeed;  //sets player gravity to jumpspeed. 
            }
        }
    }
    #endregion

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Void"))
        {
            playerController.enabled = false;
            playerController.transform.position = spawnPos;
            playerController.enabled = true;
        }

        if (other.gameObject.CompareTag("Goal"))
        {
            SceneManager.LoadScene("Final Win Scene");
        }
    }
}
