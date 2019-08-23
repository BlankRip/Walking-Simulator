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

    void Start()
    {
        dialogIndex = 0;
        text = GetComponent<Text>();
        StartCoroutine(TypeWriteEffect());                        // Displaying the first dialog when the pannel appears
    }


    void Update()
    {
        // If E is pressed then moving to diplay the next dialogue
        if(Input.GetKeyDown(KeyCode.E))
        {
            dialogIndex++;
            // If the last dialog was displayed then turn off the pannal else move to displaying the next dialog
            if (dialogIndex >= myDialogs.Length)
                transform.parent.gameObject.SetActive(false);
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
