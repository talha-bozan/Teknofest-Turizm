using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{   [SerializeField] CharacterController controller;
    public float speed = 12f;
    Vector3 JumpVelocity;
    public float gravity = -9.81f;
    public Transform groundChecker;
    public float groundRad = 0.5f;
    public LayerMask layer;
    bool isGrounded;
    public float jumpHeight = 3f;
    void Update()
    {   float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        JumpVelocity.y += gravity * Time.deltaTime;
        controller.Move(JumpVelocity*Time.deltaTime);

        isGrounded = Physics.CheckSphere(groundChecker.position, groundRad, layer);

        if(isGrounded && JumpVelocity.y < 0f){
            JumpVelocity.y = -2f;
        }
     
        if(Input.GetButtonDown("Jump") && isGrounded){

            JumpVelocity.y = Mathf.Sqrt(jumpHeight* -2f * gravity);
        }


    }
}
