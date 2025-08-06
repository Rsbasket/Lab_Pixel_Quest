using UnityEngine;

public class TrainAwareMovement : MonoBehaviour
{
    public float baseSpeed = 5f;           // Normal speed
    public float speedPenalty = 0.5f;      // Speed lost per homeless person
    public float baseScale = 1f;           // Default player size
    public float scalePerPerson = 0.1f;    // Growth per homeless person

    private float currentSpeed;
    private Rigidbody2D rb;
    private Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        UpdateSpeedAndScale();
    }

    void Update()
    {
        // Get movement input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        UpdateSpeedAndScale();
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
    }

    void UpdateSpeedAndScale()
    {
        int count = GameManager.Instance != null ? GameManager.Instance.homelessCount : 0;

        // Adjust speed (but never below 1)
        currentSpeed = Mathf.Max(1f, baseSpeed - (speedPenalty * count));

        // Adjust player scale
        float newScale = baseScale + (scalePerPerson * count);
        transform.localScale = new Vector3(newScale, newScale, 1f);
    }
}
