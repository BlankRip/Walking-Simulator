using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SkullScript : MonoBehaviour
{
    [SerializeField] GameObject touchSkullInstruct;          // The panal to display when playe in range to touch the skull
    [SerializeField] GameObject tbcPannal;                   // The panal to display the to be continued bevoer moving to the main menu

    [HideInInspector] public bool leftLit;                   // To check if the left torch is lit
    [HideInInspector] public bool rightLit;                  // To check if the right torch is lit
    bool inrange;                                            // To check if player is in range to touch the skull

    // Update is called once per frame
    void Update()
    {
        // If the player is in range and E is pressed the player will be hit and to be continued will be displayed
        if (Input.GetKeyDown(KeyCode.E) && inrange)
        {
            tbcPannal.SetActive(true);
            StartCoroutine(backToMenu());
        }
    }

    // Check if player is in trigger collider and if both the torches are lit then set in range
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player" && leftLit && rightLit)
        {
            inrange = true;
            touchSkullInstruct.SetActive(true);
        }
    }

    // Check if player is out of trigger collider and if both the torches are lit then set to be out of range
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player" && leftLit && rightLit)
        {
            inrange = false;
            touchSkullInstruct.SetActive(false);
        }
    }

    // IEnumerator to wait and move to main menu
    IEnumerator backToMenu()
    {
        yield return new WaitForSeconds(3.5f);
        SceneManager.LoadScene(0);
    }
}
