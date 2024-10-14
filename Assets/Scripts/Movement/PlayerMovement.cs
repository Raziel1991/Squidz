using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    
    public float rotationSpeed = 100f;  // Rotation sensitivity
    public float impulseForce = 10f;    // Force of the shot backward
    public float movementDuration = 50f;  // How long the movement should last
    public float maxDistance = 50f;      // Maximum distance to move before stopping
    public GunBehavior gun;


    private Rigidbody2D rb;
    private bool isMoving = false;
    private Vector2 startPosition;
    private float moveTimeRemaining;

    public ProjectileBase projectilePrefab;

    void Start()
    {
        // Get the Rigidbody2D component attached to the player
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        HandleRotation();

        // Detect shooting input (e.g., pressing Left Shift to shoot backward)
        if (Input.GetKey(KeyCode.LeftControl) && !isMoving)
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

        rb.velocity = Vector2.zero;
        rb.AddForce(-transform.up * gun.Shoot(), ForceMode2D.Impulse);

        // Start tracking movement time and position
        startPosition = rb.position;
        moveTimeRemaining = movementDuration;

        //Shoot bullet
        //ProjectileBase projectile = Instantiate(this.projectilePrefab, this.transform.position, this.transform.rotation);
       // projectile.Project(this.transform.up);

        isMoving = true;
    }

    void HandleMovement()
    {
        // Decrease the remaining time for movement
        moveTimeRemaining -= Time.deltaTime;

        // Stop the movement based on time or distance
        if (moveTimeRemaining <= 0)
        {
            // Stop the object by setting the velocity to zero
            rb.velocity = Vector2.zero;
            isMoving = false;
        }
    }
}
