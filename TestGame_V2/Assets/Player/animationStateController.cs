using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{

    private Animator animator;
    private int isWalkingHash;
    private int isRunningHash;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        Debug.Log(animator);

        isWalkingHash = Animator.StringToHash("IsWalking");
        isRunningHash = Animator.StringToHash("IsRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isRunning = animator.GetBool(isRunningHash);
        bool isWalking = animator.GetBool(isWalkingHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");

        //The player presses w to move forward
        if(!isWalking && forwardPressed)
        {
            //isWalking gets set to true
            animator.SetBool(isWalkingHash, true);
        }

        //The player stops pressing w
        if(isWalking && !forwardPressed)
        {
            //isWalking gets set to false
            animator.SetBool(isWalkingHash, false);
        }

        //The player is pressing w and left-shift and isn't already running
        if(!isRunning && (forwardPressed && runPressed))
        {
            //isRunning set to true
            animator.SetBool(isRunningHash, true);
        }

        //The player is running and stops pressing left-shift or w
        if(isRunning && (!forwardPressed || !runPressed))
        {
            //isRunning set to false
            animator.SetBool(isRunningHash, false);
        }
    }
}
