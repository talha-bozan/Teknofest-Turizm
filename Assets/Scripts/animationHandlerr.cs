using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationHandlerr : MonoBehaviour
{   Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        bool forwardPressed = Input.GetKey("w");
        bool runPressed = Input.GetKey("left shift");
        bool jumpPressed = Input.GetKey("space");
        bool isWalking = animator.GetBool("isWalk");
        bool isRunning = animator.GetBool("isRun");
        bool isJump = animator.GetBool("isJumpp");
        if(!isWalking && forwardPressed){
            animator.SetBool("isWalk",true);

        }
        if(isWalking && !forwardPressed){
            animator.SetBool("isWalk",false);
        }
        if(!isRunning && (forwardPressed && runPressed)){
            animator.SetBool("isRun", true);

        }
        if(isRunning && (!forwardPressed || !runPressed)){
            animator.SetBool("isRun", false);

        }
        if(!isJump && jumpPressed){
            animator.SetBool("isJumpp", true);
        }
        if(isJump && !jumpPressed){
            animator.SetBool("isJumpp", false);
        }
    }
}
