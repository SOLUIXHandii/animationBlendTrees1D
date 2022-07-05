using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{
    Animator animator;
    int isWalkingHash;
    int isRunningHash;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        //StringToHash Generates an parameter id from a string.
        isWalkingHash = Animator.StringToHash("isWalking");
        isRunningHash = Animator.StringToHash("isRunning");
    }

    // Update is called once per frame
    void Update()
    {
        bool isWalking = animator.GetBool(isWalkingHash);
        bool isRunning = animator.GetBool(isRunningHash);
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        // if player prees w key
        if (!isWalking && forwardPressed)
        {
            //then set boolean isWalking true
            animator.SetBool(isWalkingHash, true);
        }

        // if player is not prees w key
        if (isWalking && !forwardPressed)
        {
            //then set boolean isWalking false
            animator.SetBool(isWalkingHash, false);
        }

        // is player is walking  and not running  and press left shift
        if(!isRunning && (forwardPressed && runPressed))
        {
            //then set the isRunning boolean true
            animator.SetBool(isRunningHash, true);
        }

        //if player is running and stoops running or stop wallking
        if(isRunning && (!forwardPressed || !runPressed))
        {
            //then set the isRunning to be false 
            animator.SetBool(isRunningHash, false);
        }
    }
}
