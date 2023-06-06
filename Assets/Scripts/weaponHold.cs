using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponHold : MonoBehaviour
{
    // Start is called before the first frame update
    // get animator inside player object and weapon hold object
    private Animator weaponHoldAnimator;
    void Start()
    {
        weaponHoldAnimator = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // fix animation delay
        AnimatorStateInfo stateInfo = weaponHoldAnimator.GetCurrentAnimatorStateInfo(0);

        // if player presses left click, call the attack trigger
        if (Input.GetKeyDown(KeyCode.Q) && stateInfo.IsName("isIdle"))
        {
            // set the attack animation to true
            weaponHoldAnimator.SetTrigger("attackTrigger");
        }
        
        // if player presses left click and is walking, call the attack trigger
        if (Input.GetKeyDown(KeyCode.Q) && stateInfo.IsName("isWalk"))
        {
            // set the attack animation to true
            weaponHoldAnimator.SetTrigger("attackTrigger");
        }

        // if player is moving, call the walking animation
        if (Input.GetKey("w") || Input.GetKey("a") || Input.GetKey("s") || Input.GetKey("d"))
        {
            // set the walking animation to true
            weaponHoldAnimator.SetBool("isWalk", true);
        }
        else
        {
            // set the walking animation to false
            weaponHoldAnimator.SetBool("isWalk", false);
        }
    }
}
