using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseScript : MonoBehaviour
{
    [SerializeField] GameObject pauseScreen;                   // Pause panal
    bool paused = false;                                       // Checking if already pasused

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            // Turn on pause screen if not paused
            if(!paused)
            {
                Time.timeScale = 0;
                pauseScreen.SetActive(true);
                paused = true;
            }
            // Turn off pause screen if already paused
            else if(paused)
            {
                pauseScreen.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;
                paused = false;
            }

        }
    }
}
