using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TypeWrightText : MonoBehaviour
{
    [SerializeField] string[] myDialogs;
    Text text;
    int dialogIndex = 0;

    void Start()
    {
        text = GetComponent<Text>();
        StartCoroutine(TypeWriteEffect());
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            dialogIndex++;
            if (dialogIndex >= myDialogs.Length)
                transform.parent.gameObject.SetActive(false);
            else
                StartCoroutine(TypeWriteEffect());
        }
    }

    IEnumerator TypeWriteEffect()
    {
        text.text = "";
        int index = 0;
        while(true)
        {
            if (index >= myDialogs[dialogIndex].Length)
                break;
            text.text += myDialogs[dialogIndex][index].ToString();
            index++;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
