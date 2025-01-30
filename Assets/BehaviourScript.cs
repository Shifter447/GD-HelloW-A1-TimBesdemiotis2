using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float moveSpeed = 5f; // Movement speed
    public float turnSpeed = 10f; // Speed of turning
    public Animator animator; // Animator for movement animations
    public Camera playerCamera; // Camera to determine mouse position

    void Update()
    {
        // Get input from the user (WASD or arrow keys)
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        // Create a movement vector based on input (no diagonals)
        Vector3 move = new Vector3(moveX, 0, moveZ).normalized;

        // If there is no movement, stop early
        if (move.magnitude < 0.1f) return;

        // Move the character in the desired direction
        transform.Translate(move * moveSpeed * Time.deltaTime, Space.World);

        // Reset all animations before applying new movement
        animator.SetBool("WalkForwards", false);
        animator.SetBool("WalkBackwards", false);
        animator.SetBool("WalkLeft", false);
        animator.SetBool("WalkRight", false);

        // Apply movement animations based on input
        if (moveZ > 0.1f) // Walk Forward
        {
            animator.SetBool("WalkForwards", true);
        }
        else if (moveZ < -0.1f) // Walk Backward
        {
            animator.SetBool("WalkBackwards", true);
        }
        else if (moveX < -0.1f) // Walk Left
        {
            animator.SetBool("WalkLeft", true);
        }
        else if (moveX > 0.1f) // Walk Right
        {
            animator.SetBool("WalkRight", true);
        }
    }
}