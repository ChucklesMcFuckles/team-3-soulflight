using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;

    private float xRotation = 0f;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

        /*// Lets the player control the camera with the mouse and uses cameraSensitivity to control the speed
        playerBody.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * mouseSensitivity, Input.GetAxis("Mouse X") * mouseSensitivity, 0));

        // Stops the camera from rolling along the Z axis
        playerBody.transform.localEulerAngles = new Vector3(playerBody.transform.localEulerAngles.x, playerBody.transform.localEulerAngles.y, 0);
        */    
    }
}
