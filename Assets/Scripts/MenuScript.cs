using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScript : MonoBehaviour
{
    [SerializeField] GameObject menu;                 // The menu panal
    [SerializeField] GameObject control;              // The control panal

    // Function to show the control screen when the button was clicked
    public void ShowControls()
    {
        menu.SetActive(false);
        control.SetActive(true);
    }

    // Function to move to the next scene when the button is clicked
    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
