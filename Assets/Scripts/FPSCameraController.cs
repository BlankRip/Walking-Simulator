using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCameraController : MonoBehaviour
{
    [SerializeField] float sensitivity;            // The speed at which the camera will move.
    float mouseX;                                  // The value the mouse is moved on the X axis 
    float mouseY;                                  // The value the mouse is moved on the Y axis
    [SerializeField] float mouseYMin;              // Minimum of Y axis clipping
    [SerializeField] float mouseYMax;              //Maximum of Y axis clipping

    private void Start()
    {
        Cursor.visible = false;
    }

    void LateUpdate()
    {
        mouseX += Input.GetAxis("Mouse X") * sensitivity;                 // Getting the rotaion value around Y axis by adding the mouse inutp position in the game world.
        mouseY -= Input.GetAxis("Mouse Y") * sensitivity;                 // Getting the rotaion value around X axis by adding the mouse inutp position in the game world.
        mouseY = Mathf.Clamp(mouseY, mouseYMin, mouseYMax);               // Clipping Y values so that the player can't virtically look in 360 degrees

        transform.rotation = Quaternion.Euler(0, mouseX, 0);                              // Rotating player with change in mouse X value
        Camera.main.transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);             // Rotationg camera with change in mouse X and Y values
    }
}
