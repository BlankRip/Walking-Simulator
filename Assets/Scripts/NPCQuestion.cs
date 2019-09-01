using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCQuestion : MonoBehaviour
{
    NPCScript theScript;

    // Start is called before the first frame update
    void Start()
    {
        theScript = FindObjectOfType<NPCScript>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NextPoint")
        {
            if (theScript.index <= theScript.wayPoints.Length - 2)
                theScript.index++;
        }
        else if (other.tag == "QuestionPoint")
        {
            theScript.animate.SetBool("WalkingNow", false);
            theScript.currentState = NPCScript.NPCStates.Questioning;
        }
        else if (other.tag == "LastPoint")
        {
            theScript.animate.SetBool("WalkingNow", false);
            theScript.currentState = NPCScript.NPCStates.Beatup;
        }
    }
}
