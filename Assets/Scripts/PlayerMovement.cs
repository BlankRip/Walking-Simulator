using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float normalSpeed;                    // The normal speed the player will move in the game
    [SerializeField] float sprintMultipler;                // The number multiplied to normal speed to give sprint speed
    [SerializeField] int jumpForce;                        // The velocity increase in Y axis to perform jump
    float sprintSpeed;                                     // The speed at which player sprints in the game
    float speed;                                           // The current speed of the player
    Vector3 keyboardInput;                                 // The movemnet inputs from the keyboard (set direction to move)
    Rigidbody playerRb;                                    // rigid body of the player
    [HideInInspector] public bool grounded = true;                 // checking if player on the ground

    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        sprintSpeed = normalSpeed * sprintMultipler;       // Setting sprint speed
    }

    private void Update()
    {
        // Setting current speed based on if player is sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = sprintSpeed;
        }
        else
            speed = normalSpeed;
        // Getting keyboard inputs
        keyboardInput = (transform.right * Input.GetAxisRaw("Horizontal")) + (transform.forward * Input.GetAxisRaw("Vertical"));
    }

    void FixedUpdate()
    {
        //Moving player
        playerRb.velocity = (keyboardInput.normalized * speed) + (new Vector3(0, playerRb.velocity.y, 0));

        //Performing jump if player on the ground
        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            playerRb.velocity = new Vector3(0, Input.GetAxis("Jump") * jumpForce, 0);
        }
    }


    //Checking if colling with ground to set grounded
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            grounded = false;
        }
    }
}
