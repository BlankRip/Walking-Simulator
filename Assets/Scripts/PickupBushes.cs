using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupBushes : MonoBehaviour
{
    [SerializeField] GameObject pickUpInstructions;
    bool readyToTake;
    BringStuffConvo tracker;


    private void Start()
    {
        tracker = FindObjectOfType<BringStuffConvo>();
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.E) && readyToTake)
        {
            tracker.collected++;
            pickUpInstructions.SetActive(false);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player" && tracker.collectableNow)
        {
            readyToTake = true;
            pickUpInstructions.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && tracker.collectableNow)
        {
            readyToTake = false;
            pickUpInstructions.SetActive(false);
        }
    }

}
