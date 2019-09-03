using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuestion : MonoBehaviour
{
    NPCScript theScript;                     // The NPC script to check the waypoints

    void Start()
    {
        theScript = FindObjectOfType<NPCScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        // What the player should do when the NPC gets to a waypoint
        if (other.tag == "NextPoint")
        {
            if (theScript.index <= theScript.wayPoints.Length - 2)
                theScript.index++;                                         // Adding one to the index so that the npc will move to the next way point
        }
        else if (other.tag == "QuestionPoint")
        {
            theScript.animate.SetBool("WalkingNow", false);               // Making the npc to stop walking animation
            theScript.currentState = NPCScript.NPCStates.Questioning;     // Make the NPC ask the Question if on that perticular waypoint
        }
        else if (other.tag == "LastPoint")
        {
            theScript.animate.SetBool("WalkingNow", false);               // Making the npc to stop walking animation
            theScript.currentState = NPCScript.NPCStates.Beatup;          // Setting the NPC to the the final puzzle activating state when on the perticular waypoint
        }
    }
}
