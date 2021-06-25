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

    void Awake()
    {
        // characterController = GetComponent<CharacterController>();
        gravity = Physics.gravity;
        // playerVelocity.y = 3;
        // Debug.Log(gravity);
    }

    void Update()
    {
        if (!characterController.isGrounded)
        {
            characterController.Move(gravity * Time.deltaTime);
            Debug.Log("Player touch ground");
            // playerVelocity.y = 0;
        }

        Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        characterController.Move(movement * Time.deltaTime * playerSpeed);

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
}
