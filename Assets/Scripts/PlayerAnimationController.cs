using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animate;                    // The player animator
    bool jumpin;                         // To check if player is in jumping state

    void Start()
    {
        animate = GetComponent<Animator>();
    }


    void Update()
    {
        // Setting the animation state based on which key is pressed
        if(Input.GetKeyDown(KeyCode.Space) && jumpin)
        {
            animate.SetTrigger("Jump");
        }


        if (Input.GetAxis("Horizontal") != 0)
        {
            animate.SetFloat("Move", 1);
            animate.SetFloat("Forward Or Right", -1);
            if (Input.GetAxis("Horizontal") > 0)
                animate.SetFloat("Left and Right", 1);
            else if(Input.GetAxis("Horizontal") < 0)
                animate.SetFloat("Left and Right", -1);

        }
        else if (Input.GetAxis("Vertical") != 0)
        {
            animate.SetFloat("Move", 1);
            animate.SetFloat("Forward Or Right", 1);
            if (Input.GetAxis("Vertical") > 0)
                animate.SetFloat("Front and back", 1);
            else if (Input.GetAxis("Vertical") < 0)
                animate.SetFloat("Front and back", -1);
        }

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0 && !jumpin)
            animate.SetFloat("Move", 0);
    }


    //Checking if colling with ground to set grounded
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpin = false;
        }
    }
    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            jumpin = true;
        }
    }
}
