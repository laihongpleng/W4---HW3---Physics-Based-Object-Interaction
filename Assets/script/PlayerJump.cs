using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpHeight = 6f;
    CharacterController controller;
    MovementInput movementScript;

    void Start()
    {
        controller = GetComponent<CharacterController>();
        movementScript = GetComponent<MovementInput>();
    }

    void Update()
    {
        if (controller.isGrounded)
        {
            // If press Space → jump
            if (Input.GetKeyDown(KeyCode.Space))
            {
                movementScript.verticalVel = jumpHeight;
            }
        }
    }
}
