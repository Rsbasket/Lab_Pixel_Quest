using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoQScript : MonoBehaviour
{
    int var = 3;
    public int speed = 9;
    public float jumpForce = 12f; // Added jump force
    public string nextLevel = "Scene_2";
    private Rigidbody2D rb;
    private bool isGrounded = false; // Track if player is on the ground

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
        // Jumping with 'W'
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Simple ground check: tag your ground objects as "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit");
        switch (collision.tag)
        {
            case "Win":
                break;
            case "Lose":
                break;
            case "Death":
                string thisLevel = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(thisLevel);
                break;
            case "Finish":
                SceneManager.LoadScene(nextLevel);
                break;
        }
    }
}