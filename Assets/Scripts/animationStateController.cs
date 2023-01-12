using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationStateController : MonoBehaviour
{   Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    void Update()   //declerations
    {   bool isRunning = animator.GetBool("isRunning");
        bool isWalking = animator.GetBool("isWalking");
        bool isJump = animator.GetBool("isJump");
        bool forwardPress = Input.GetKey("w");
        bool runPress = Input.GetKey("left shift");
        bool jumpPress = Input.GetKey("space");
        //walk animation with w
        if(!isWalking && forwardPress){
            animator.SetBool("isWalking",true);
        }
        if(isWalking && !forwardPress){
                animator.SetBool("isWalking",false);
        }

        //run animation with shift
        if(!isRunning && (forwardPress && runPress)){
            animator.SetBool("isRunning" ,true);
            
        }
        if(isRunning && (!forwardPress || !runPress)){
            animator.SetBool("isRunning" ,false);
        }

        //jump animations with space
        if(jumpPress){
            animator.SetBool("isJump", true);
        }
        if(!jumpPress){
        animator.SetBool("isJump", false);
        }
        
        
    }
    
}
