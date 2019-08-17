using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    Animator animate;
    float speedValue;
    void Start()
    {
        animate = GetComponent<Animator>();
    }


    void Update()
    {
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

        if (Input.GetAxis("Horizontal") == 0 && Input.GetAxis("Vertical") == 0)
            animate.SetFloat("Move", 0);
    }
}
