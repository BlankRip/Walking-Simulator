using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionAnswers : MonoBehaviour
{
    [SerializeField] bool answerIs1;
    [SerializeField] bool answerIs2;
    [SerializeField] bool answerIs3;
    [SerializeField] GameObject correct;
    [SerializeField] GameObject wrong;
    PlayerMovement player;
    NPCScript npcNowPos;

    private void Start()
    {
        player = FindObjectOfType<PlayerMovement>();
        npcNowPos = FindObjectOfType<NPCScript>();
        player.moveState = PlayerMovement.movementState.talking;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha1))
        {
            if(answerIs1)
            {
                npcNowPos.currentState = NPCScript.NPCStates.InRange;
                npcNowPos.questionNo++;
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


    IEnumerator StopMoveAfterWrong()
    {
        yield return new WaitForSeconds(0.3f);
        player.moveState = PlayerMovement.movementState.talking;
    }

}
