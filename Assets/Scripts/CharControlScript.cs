using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharControlScript : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 12f;
    Vector3 jumpVelocity;
    float gravity = -9.81f;

    public Transform groundChecker;

    float groundRad = 0.4f;
    public LayerMask layer;
    bool isGround;
    public float jumpHeight = 3f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics.CheckSphere(groundChecker.position, groundRad, layer);
        if (isGround && jumpVelocity.y < 0f)
        {
            jumpVelocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGround)
        {
            jumpVelocity.y = Mathf.Sqrt(-2 * jumpHeight * gravity);

        }
        //write a code for run algorithm
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = 20f;
        }
        else
        {
            speed = 12f;
        }


        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        Vector3 move = (transform.right * x) + (transform.forward * z);
        controller.Move(move * Time.deltaTime * speed);
        jumpVelocity.y += gravity * Time.deltaTime;
        controller.Move(jumpVelocity * Time.deltaTime);
    }
}