using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainAwareMovement : MonoBehaviour
{
    public float moveSpeed = 5f;         // Normal movement speed
    private float currentSpeed;          // Current speed (modified for boosts)
    private Rigidbody2D rb;              // Rigidbody2D component for physics-based movement
    private SpriteRenderer sr;           // SpriteRenderer component to flip the sprite

    private float boostEndTime = 0f;     // Time when the speed boost should end

    void Start()
    {
        // Get Rigidbody2D and SpriteRenderer components
        rb = GetComponent<Rigidbody2D>();               // Ensure Rigidbody2D is attached to the player object
        sr = GetComponentInChildren<SpriteRenderer>();  // Ensure SpriteRenderer is attached to the player or a child

        currentSpeed = moveSpeed;  // Set initial speed
    }

    void Update()
    {
        // Get horizontal and vertical input
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = Input.GetAxisRaw("Vertical");

        // Apply movement using Rigidbody2D's velocity
        rb.velocity = new Vector2(xInput * currentSpeed, yInput * currentSpeed);

        // Flip the sprite depending on movement direction
        if (xInput > 0)
        {
            sr.flipX = true; // Facing right (normal)
        }
        else if (xInput < 0)
        {
            sr.flipX = false;  // Facing left (flipped)
        }

        // If the boost duration has ended, reset speed to normal
        if (Time.time >= boostEndTime)
        {
            currentSpeed = moveSpeed;  // Reset speed back to normal
        }
    }

    // Method to apply speed boost
    public void ApplySpeedBoost(float boostAmount, float duration)
    {
        currentSpeed = moveSpeed * boostAmount;  // Multiply current speed by the boost amount
        boostEndTime = Time.time + duration;     // Set the end time for the boost duration
    }
}
