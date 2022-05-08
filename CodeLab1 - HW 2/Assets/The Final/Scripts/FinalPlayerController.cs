using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalPlayerController : MonoBehaviour
{

    [SerializeField]
    private float moveSpeed = 1.5f;

    Vector3 moveInput;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().velocity = moveInput * moveSpeed;

        
    }
}
