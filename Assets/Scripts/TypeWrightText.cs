using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWrightText : MonoBehaviour
{
    [SerializeField] string[] myDialogs;                          // Strings of the dialogs to be displayed
    [SerializeField] [Range(0, 1)] float typeSpeed;               // The speed at which the text will be displayed letter by letter
    Text text;                                                    // The text component in the pannel
    int dialogIndex;                                              // Keeping track of which dialog is being displayed
    [SerializeField] bool replayable;                             // Make it true if the conversation is replayable
    int replayTimes;                                              // The number of times replayed
    bool reset;                                                   // check if replayed then reset all the values
    PlayerMovement stopPlayerMove;

    void Start()
    {
        stopPlayerMove = FindObjectOfType<PlayerMovement>();
        stopPlayerMove.moveState = PlayerMovement.movementState.talking;   // setting player to talking state
        dialogIndex = 0;
        text = GetComponent<Text>();
        StartCoroutine(TypeWriteEffect());                        // Displaying the first dialog when the pannel appears
    }


    void Update()
    {
        // If E is pressed then moving to diplay the next dialogue
        if(Input.GetKeyDown(KeyCode.E))
        {
            // Check if the conversation is being replayed if so set start values
            if (reset && replayTimes > 0)
            {
                Start();
                reset = false;
            }

            dialogIndex++;
            // If the last dialog was displayed then turn off the pannal else move to displaying the next dialog
            if (dialogIndex >= myDialogs.Length)
            {
                // If replayable setting the stuff for when the conversation is replayed
                if(replayable)
                {
                    reset = true;
                    text.text = myDialogs[0];
                    replayTimes++;
                }
                transform.parent.gameObject.SetActive(false);
                stopPlayerMove.moveState = PlayerMovement.movementState.moving;  //setting player back to moveable state
            }
            else
                StartCoroutine(TypeWriteEffect());
        }
    }
    
    //Coroutin to display the current dialog letter by letter
    IEnumerator TypeWriteEffect()
    {
        text.text = "";
        int index = 0;                                          //Keeps track of which letter of the string to display next and it is on at the movement
        while(true)
        {
            //If the last letter was displayed then break from the loop else continue to display the next letters
            if (index >= myDialogs[dialogIndex].Length)
                break;
            text.text += myDialogs[dialogIndex][index].ToString();
            index++;
            yield return new WaitForSeconds(typeSpeed);         //The time gap between the display of each letter
        }
    }
}
