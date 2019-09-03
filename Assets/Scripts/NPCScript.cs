using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    // The states the NPC will be in (state machine)
    public enum NPCStates { InRange, OutRange, Questioning, Beatup}
    public NPCStates currentState;

    [SerializeField] public Animator animate;                                // Enemy animator
    [SerializeField] public GameObject[] wayPoints;                          // The array of waypoints the NPC will navigate through
    [SerializeField] GameObject question1;                                   // Panal with question 1
    [SerializeField] GameObject question2;                                   // Panal with question 2
    [SerializeField] GameObject question3;                                   // Panal with question 3
    [SerializeField] GameObject player;                                      // The player object
    [SerializeField] GameObject finalPuzzleInstruct;                         // The text panal which expains the final puzzle
    [SerializeField] GameObject lighter;                                     // The light ball gameobject
    [SerializeField] SphereCollider Tcollider;                               // The isTrigger collider connected to the npc which controls it's movment based on if player in range
    [HideInInspector] public int questionNo;                                 // int to keep traack of the question number
    [HideInInspector] public int index = 0;                                  // which waypoint it is at or moving to right now
    [HideInInspector] public bool finalPuzzleOn;                             // To activate things required for the final puzzle


    private void Start()
    {
        currentState = NPCStates.OutRange;
        questionNo = 1;
        Tcollider = GetComponent<SphereCollider>();
    }


    private void Update()
    {
        // Perform diffrent actions based on which state the NPC is in
        switch (currentState)
        {
            case NPCStates.InRange:                            // When player in range the NPC will look at the next way point and walk to it with root animations
                {
                    transform.LookAt(new Vector3(wayPoints[index].transform.position.x, transform.position.y, wayPoints[index].transform.position.z));
                    animate.SetBool("WalkingNow", true);
                    break;
                }
            case NPCStates.OutRange:                           // When player is out of range the NPC will not move and look at player
                {
                    animate.SetBool("WalkingNow", false);
                    transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
                    break;
                }
            case NPCStates.Questioning:                       // When Npc is ready to question it will check which question to display based on which question number it is
                {
                    if (questionNo == 1)
                        question1.SetActive(true);
                    else if (questionNo == 2)
                        question2.SetActive(true);
                    else if (questionNo == 3)
                        question3.SetActive(true);
                }
                break;
            case NPCStates.Beatup:                            // When reach the final waypoint will display what to do in the last puzzle and stops tacking by removing the isTrigger collider
                {
                    if(Tcollider.enabled == true)
                    {
                        Tcollider.enabled = false;
                        finalPuzzleOn = true;
                        finalPuzzleInstruct.SetActive(true);
                        lighter.SetActive(true);
                    }
                    transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
                }
                break;
            default:
                break;
        }
    }


    // When player in collider it is set to be in range
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            currentState = NPCStates.InRange;
        }
    }

    // When player out of collider it is set to be out of range
    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            currentState = NPCStates.OutRange;
        }
    }
}
