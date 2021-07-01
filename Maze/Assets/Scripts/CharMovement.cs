using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    [SerializeField] CharacterController characterController;
    private Vector3 gravity;
    private Vector3 playerVelocity;
    [SerializeField] float playerSpeed;
    [SerializeField] float jumpHeight;

    [SerializeField] Transform cam;

    [SerializeField] float turnSmoothTime = 0.1f;
    private float turnSmoothVelocity;

    void Awake()
    {
        // characterController = GetComponent<CharacterController>();
        gravity = Physics.gravity;
        // playerVelocity.y = 3;
        // Debug.Log(gravity);
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        Movement();

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

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical).normalized;
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
                moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.back;
            }

            characterController.Move(moveDir.normalized * Time.deltaTime * playerSpeed);
        }
    }
}
