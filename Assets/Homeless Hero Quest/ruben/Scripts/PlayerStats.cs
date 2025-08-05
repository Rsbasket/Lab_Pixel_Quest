using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float verticalSpeed = 3f;

    public string Train1Scene = "FirstTrain";
    public string Train2Scene = "SecondTrain";

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }

        rb.velocity = new Vector2(horizontalInput * moveSpeed, verticalInput * verticalSpeed);

        HandlePlayerFlip(horizontalInput);
    }

    private void HandlePlayerFlip(float horizontalInput)
    {
        if (pickup == null) return;

        if (horizontalInput < 0)
        {
            pickup.facingLeft = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            pickup.facingLeft = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Hit: " + collision.tag);

        switch (collision.tag)
        {
            case "Win":
                SceneManager.LoadScene(Train1Scene);
                break;

            case "Lose":
                SceneManager.LoadScene(Train2Scene);
                break;

            case "Death":
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
                break;

            case "Finish":
                SceneManager.LoadScene(Train2Scene); // or Train1Scene depending on your game flow
                break;
        }
    }
}
