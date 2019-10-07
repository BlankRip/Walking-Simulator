using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBushes : MonoBehaviour
{
    [SerializeField] GameObject pickUpInstructions;         // Panal which displays the instructions to pick up the bush when in range
    bool readyToTake;                                       // to check if the bush is in range
    BringStuffConvo tracker;                                // The script that tracks the number of bushes being collected
    [SerializeField] AudioSource soundEffect;               // The audio source
    [SerializeField] AudioClip pickUpSe;                    // The clip played when picked up


    private void Start()
    {
        tracker = FindObjectOfType<BringStuffConvo>();
    }

    private void Update()
    {
        // If the player is in collection range and presses E he will collect the bush 
        if(Input.GetKeyDown(KeyCode.E) && readyToTake)
        {
            soundEffect.PlayOneShot(pickUpSe);
            tracker.collected++;
            pickUpInstructions.SetActive(false);
            Destroy(gameObject);
        }
    }

    // To check if the player is in the trigger collider then set to inrange
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && tracker.collectableNow)
        {
            readyToTake = true;
            pickUpInstructions.SetActive(true);
        }
    }

    // To check if the player is outside the trigger collider that is set to out of range
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && tracker.collectableNow)
        {
            readyToTake = false;
            pickUpInstructions.SetActive(false);
        }
    }

}
