using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCScript : MonoBehaviour
{
    public enum NPCStates { InRange, OutRange, Questioning, Beatup}
    public NPCStates currentState;

    [SerializeField] public Animator animate;
    [SerializeField] public GameObject[] wayPoints;
    [SerializeField] GameObject question1;
    [SerializeField] GameObject question2;
    [SerializeField] GameObject question3;
    [SerializeField] GameObject player;
    [SerializeField] GameObject finalPuzzleInstruct;
    [SerializeField] SphereCollider Tcollider;
    [HideInInspector] public int questionNo;
    [HideInInspector] public int index = 0;                                   // which waypoint it is at or moving to right now
    [HideInInspector] public bool finalPuzzleOn;


    private void Start()
    {
        currentState = NPCStates.OutRange;
        questionNo = 1;
        Tcollider = GetComponent<SphereCollider>();
    }


    private void Update()
    {
        switch (currentState)
        {
            case NPCStates.InRange:
                {
                    transform.LookAt(new Vector3(wayPoints[index].transform.position.x, transform.position.y, wayPoints[index].transform.position.z));
                    animate.SetBool("WalkingNow", true);
                    break;
                }
            case NPCStates.OutRange:
                {
                    animate.SetBool("WalkingNow", false);
                    transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
                    break;
                }
            case NPCStates.Questioning:
                {
                    if (questionNo == 1)
                        question1.SetActive(true);
                    else if (questionNo == 2)
                        question2.SetActive(true);
                    else if (questionNo == 3)
                        question3.SetActive(true);
                }
                break;
            case NPCStates.Beatup:
                {
                    if(Tcollider.enabled == true)
                    {
                        Tcollider.enabled = false;
                        finalPuzzleOn = true;
                        finalPuzzleInstruct.SetActive(true);
                    }
                    transform.LookAt(new Vector3(player.transform.position.x, transform.position.y, player.transform.position.z));
                }
                break;
            default:
                break;
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            currentState = NPCStates.InRange;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.tag == "Player")
        {
            currentState = NPCStates.OutRange;
        }
    }
}
