using UnityEngine;
using System.Collections;

public class TrainAwareMovement : MonoBehaviour
{
    public float baseSpeed = 5f;           // Speed with 0 homeless
    public float speedPenalty = 0.5f;      // Speed lost per homeless person
    public float baseScale = 1f;           // Starting size
    public float scalePerPerson = 0.1f;    // Size added per homeless person

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

        // Adjust speed with penalty per homeless person
        currentSpeed = Mathf.Max(1f, baseSpeed - (speedPenalty * count));

        // Adjust scale with number of homeless carried
        float newScale = baseScale + (scalePerPerson * count);
        transform.localScale = new Vector3(newScale, newScale, 1f);
    }

    // ? Apply temporary speed boost from anywhere
    public void ApplySpeedBoost(float boostAmount, float duration)
    {
        StopAllCoroutines();
        StartCoroutine(SpeedBoostRoutine(boostAmount, duration));
    }

    private IEnumerator SpeedBoostRoutine(float boostAmount, float duration)
    {
        float originalBaseSpeed = baseSpeed;
        baseSpeed += boostAmount;

        yield return new WaitForSeconds(duration);

        baseSpeed = originalBaseSpeed;
    }
}
