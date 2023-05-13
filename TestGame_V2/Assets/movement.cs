using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private Camera playerCamera;
    public float playerSpeed = 5.0f;
    public float cameraSensitivty = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = gameObject.GetComponent<CharacterController>();
        playerCamera = gameObject.GetComponent<Camera>();

        // Locks the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        move();
        cameraControl();
        gravity();
    }

    void cameraControl()
    {
        /* TODO: There's a bug that when the player looks all the way down, and continues to look down, the character rapidly spins
         * Frankly I don't think its THAT bad, but something to keep in mind */

        // Lets the player control the camera with the mouse and uses cameraSensitivity to control the speed
        playerCamera.transform.Rotate(new Vector3(-Input.GetAxis("Mouse Y") * cameraSensitivty, Input.GetAxis("Mouse X") * cameraSensitivty, 0));

        // Stops the camera from rolling along the Z axis
        playerCamera.transform.localEulerAngles = new Vector3(playerCamera.transform.localEulerAngles.x, playerCamera.transform.localEulerAngles.y, 0);
        
    }

    void gravity()
    {
        /* Adds gravity to the player */
        playerVelocity.y += Physics.gravity.y * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }

    void move()
    {
        // Gets the camera's forward vector as a Vector3 and sets the y to 0
        Vector3 cameraFacing = Vector3.Scale(playerCamera.transform.forward, new Vector3(1, 0, 1)).normalized;
        /* This section moves the player in the direction the camera is facing, and allows for strafing*/
        
        // Creates the move vector
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        
        // Changes the move vector to be relative to the camera's forward vector
        move = cameraFacing * move.z + playerCamera.transform.right * move.x;
        
        // This moves the player in the direction of the move vector
        controller.Move(move * (Time.deltaTime * playerSpeed));
    }
}
