using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController; 
    //private Vector3 gravityVector3;
    private Vector3 playerVelocity;
    private Vector3 movement;
    private Vector3 velocity;
    private Animator animator;
    private float horizontal;
    private float vertical;
    private float gravity;
    
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpHeight;

    [SerializeField] Transform cam;

    [SerializeField] float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;
    
    void Awake()
    { 
        //characterController = GetComponent<CharacterController>();
        //gravityVector3 = Physics.gravity;
        // playerVelocity.y = 3;
        // Debug.Log(gravity);
    }

    void Start()
    {
        //animator = GetComponent<Animator>();
        animator = transform.GetChild(0).GetComponent<Animator>();
        Cursor.lockState = CursorLockMode.Locked;

        gravity = 0.5f;
    }

    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");

        // if (!characterController.isGrounded)
        // {
        //     characterController.Move(gravity * Time.deltaTime);
        //     Debug.Log("Player touch ground");
        //     // playerVelocity.y = 0;
        // }

        // Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        // characterController.Move(movement * Time.deltaTime * playerSpeed);

        // else
        // {
        //     if (Input.GetButtonDown("Jump"))
        //     {
        //         Debug.Log("Player jump");
        //         playerVelocity.y += Mathf.Sqrt(5 * -3f * gravity.y);
        //         characterController.Move(playerVelocity * Time.deltaTime);
        //     }
        // }
    }

    private void FixedUpdate()
    {
        Movement();
    }

    void Movement()
    {
        movement = new Vector3(horizontal, 0, vertical).normalized;
        
        //movement = characterController.transform.forward * vertical;
        
        //characterController.transform.Rotate(Vector3.up * horizontal * (100f * Time.deltaTime));

        //characterController.Move(movement * playerSpeed * Time.deltaTime);
        
        
        if (characterController.isGrounded)
        {
            velocity.y = 0f;
        }
        else
        {
            velocity.y -= gravity * Time.deltaTime;
        }
        characterController.Move(velocity);

        // Animation
        if (horizontal == 0 && vertical ==0)
        {
            animator.SetBool("Run",false);
            animator.SetBool("Reverse", false);
        }
        else if (vertical < 0)
        {
            animator.SetBool("Reverse", true);
            animator.SetBool("Run", false);
        }
        else if (vertical > 0)
        {
            animator.SetBool("Reverse", false);
            animator.SetBool("Run",true);
        }
        else
        {
            animator.SetBool("Reverse", false);
            animator.SetBool("Run",true);
        }
        
        // Debug.Log(movement.magnitude);
        if (movement.magnitude >= 0.1f)
        {
            
            float targetAngle = Mathf.Atan2(movement.x, movement.y) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
            transform.rotation = Quaternion.Euler(0, angle, 0);

            Vector3 moveDir = Vector3.zero;
            if (vertical >= 0)
            {
                moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
            }
            else
            {
                //animator.SetBool("Reverse",false);
                moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.back;
            }

            characterController.Move(moveDir.normalized * Time.deltaTime * playerSpeed);
        }
    }
}
