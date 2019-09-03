using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAnswers : MonoBehaviour
{
    [SerializeField] bool answerIs1;                // Tick the bool in the inspector if the answer is 1
    [SerializeField] bool answerIs2;                // Tick the bool in the inspector if the answer is 2
    [SerializeField] bool answerIs3;                // Tick the bool in the inspector if the answer is 3
    [SerializeField] GameObject correct;            // The text panal to display when the correct answere was picked
    [SerializeField] GameObject wrong;              // The text panal to display when the wrong answere is picked
    PlayerMovement player;                          // Player-movement script
    NPCScript npcNowPos;                            // The npc script

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        npcNowPos = FindObjectOfType<NPCScript>();
        player.moveState = PlayerMovement.movementState.talking;
    }

    private void Update()
    {
        // If the key is pressed and then if the answer is corret it will display the text panal based on if correct or wrong
        // If correct answer will change the question number and add the waypoint index
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(answerIs1)
            {
                npcNowPos.currentState = NPCScript.NPCStates.InRange;
                npcNowPos.questionNo++;
                npcNowPos.index++;
                correct.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                wrong.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (answerIs2)
            {
                npcNowPos.currentState = NPCScript.NPCStates.InRange;
                npcNowPos.questionNo++;
                npcNowPos.index++;
                correct.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                wrong.SetActive(true);
            }
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            if (answerIs3)
            {
                npcNowPos.currentState = NPCScript.NPCStates.InRange;
                npcNowPos.questionNo++;
                npcNowPos.index++;
                correct.SetActive(true);
                gameObject.SetActive(false);
            }
            else
            {
                wrong.SetActive(true);
            }
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            StartCoroutine(StopMoveAfterWrong());
        }
    }

    // To freez player movemnt after wrong answer panal unfreezes the movement
    IEnumerator StopMoveAfterWrong()
    {
        yield return new WaitForSeconds(0.3f);
        player.moveState = PlayerMovement.movementState.talking;
    }

}
