using UnityEngine;
using UnityEngine.SceneManagement;

public class TrainAwareMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool allowVerticalMovement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

        string sceneName = SceneManager.GetActiveScene().name;
        allowVerticalMovement = (sceneName == "FirstTrain" || sceneName == "SecondTrain" || sceneName == "ThirdTrain");
    }

    void Update()
    {
        float xInput = Input.GetAxisRaw("Horizontal");
        float yInput = allowVerticalMovement ? Input.GetAxisRaw("Vertical") : 0f;

        rb.velocity = new Vector2(xInput * moveSpeed, yInput * moveSpeed);

        // Flip sprite depending on movement direction
        if (xInput > 0)
        {
            sr.flipX = true; // Facing right (normal)
        }
        else if (xInput < 0)
        {
            sr.flipX = false;  // Facing left (flipped)
        }
    }
}
