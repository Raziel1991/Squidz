using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float rotationSpeed = 100f;  // Rotation sensitivity
    public float impulseForce = 10f;    // Force of the shot backward
    public float movementDuration = 0.5f;  // How long the movement should last
    public float maxDistance = 5f;      // Maximum distance to move before stopping

    private Rigidbody2D rb;
    private bool isMoving = false;
    private Vector2 startPosition;
    private float moveTimeRemaining;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleRotation();

        // Detect shooting input (e.g., pressing Left Shift to shoot backward)
        if (Input.GetKeyDown(KeyCode.LeftShift) && !isMoving)
        {
            Shoot();
        }

        // Handle stopping logic (time-based or distance-based)
        if (isMoving)
        {
            HandleMovement();
        }
    }

    void HandleRotation()
    {
        // Rotate the player using A (left) and D (right)
        float horizontalInput = Input.GetAxis("Horizontal"); // A is -1, D is +1
        if (horizontalInput != 0)
        {
            transform.Rotate(Vector3.forward * -horizontalInput * rotationSpeed * Time.deltaTime);
        }
    }

    void Shoot()
    {
        // Apply an impulse in the opposite direction of the current rotation (backward)
        rb.AddForce(-transform.up * impulseForce, ForceMode2D.Impulse);

        // Start tracking movement time and position
        startPosition = rb.position;
        moveTimeRemaining = movementDuration;
        isMoving = true;
    }

    void HandleMovement()
    {
        // Decrease the remaining time for movement
        moveTimeRemaining -= Time.deltaTime;

        // Stop the movement based on time or distance
        if (moveTimeRemaining <= 0 || Vector2.Distance(startPosition, rb.position) >= maxDistance)
        {
            // Stop the object by setting the velocity to zero
            rb.velocity = Vector2.zero;
            isMoving = false;
        }
    }
}
