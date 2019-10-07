using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BringStuffConvo : MonoBehaviour
{
    [SerializeField] GameObject bringMeStuff;                //Converstion object
    [SerializeField] GameObject enterIn;                     // Conversation to come in
    [SerializeField] PlayerMovement playerSpeed;             // Movement script to change speed
    [HideInInspector] public bool collectableNow;            // To check if the bushes were collectable
    [HideInInspector] public int collected;                  // A counter to keep count of how many bushes are collected so far
    [SerializeField] int ColletXNumber;                      // Number of bushes are needed to be collect to enter the village
    [SerializeField] AudioSource soundSource;                                 // The audio source
    [SerializeField] AudioClip changBGS;                     // The clip to which the background music is changed to


    private void Start()
    {
        playerSpeed = FindObjectOfType<PlayerMovement>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // If the player should be let inside or is asked to bring bushes
            if (collected < ColletXNumber)
            {
                collectableNow = true;
                bringMeStuff.SetActive(true);
            }
            else if (collected >= ColletXNumber)
            {
                enterIn.SetActive(true);
                soundSource.clip = changBGS;
                soundSource.Play();
                playerSpeed.normalSpeed = 2;
                Destroy(gameObject);
            }
        }
    }
}
