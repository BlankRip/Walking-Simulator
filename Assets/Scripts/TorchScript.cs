using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchScript : MonoBehaviour
{
    SkullScript skull;                                                // Skull script referance
    NPCScript npc;                                                    // NPC script referance
    [SerializeField] GameObject vFx;                                  // Gameobject that displayes flames, smoke and sparks
    [SerializeField] GameObject LitUpInstructions;                    // Panal to show instrctions to lite the torch
    [SerializeField] GameObject wrongLitText;                         // Text panal that will show up when tried to light up the wrong torch
    [SerializeField] CapsuleCollider triggerCollider;                 // The isTrigger collider to check if in range
    [SerializeField] bool thisIsLeftStick;                            // Tick this bool if the torch is the one on the left stick
    [SerializeField] bool thisIsRigthStick;                           // Tick this bool if the torch is the one on the right stick
    bool inrange;                                                     // To check if the player is in range to light up the torch


    void Start()
    {
        skull = FindObjectOfType<SkullScript>();
        npc = FindObjectOfType<NPCScript>();
    }


    void Update()
    {
        // If it is left stick it checks if in-range then can light up if E is pressed
        if(thisIsLeftStick)
        {
            if(Input.GetKeyDown(KeyCode.E) && inrange)
            {
                vFx.SetActive(true);
                skull.leftLit = true;
                triggerCollider.enabled = false;
                LitUpInstructions.SetActive(false);
            }
        }
        // If it is the right stick it checks if the in-range and the left stick is lit then can light up if E is pressed.
        // If left stick is not lit then display light left first text
        else if(thisIsRigthStick)
        {
            if (Input.GetKeyDown(KeyCode.E) && inrange)
            {
                if (skull.leftLit)
                {
                    vFx.SetActive(true);
                    skull.rightLit = true;
                    triggerCollider.enabled = false;
                    LitUpInstructions.SetActive(false);
                }
                else
                    wrongLitText.SetActive(true);
            }
        }
        
    }

    // If player in the isTrigger collider then set to be in range and display light up instructions
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && npc.finalPuzzleOn)
        {
            inrange = true;
            LitUpInstructions.SetActive(true);
        }
    }

    // If player out of the isTrigger collider then set to be out of range and if displaying light up instruction it will be removed
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && npc.finalPuzzleOn)
        {
            inrange = false;
            LitUpInstructions.SetActive(false);
        }
    }
}
