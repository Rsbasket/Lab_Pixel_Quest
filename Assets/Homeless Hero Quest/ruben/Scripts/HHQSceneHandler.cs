using UnityEngine;
using UnityEngine.SceneManagement;

public class HHQSceneHandler : MonoBehaviour
{
    public int speed = 9;

    public string Train1Scene = "FirstTrain";
    public string Train2Scene = "SecondTrain";

    private SpriteRenderer sr;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
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
                string currentScene = SceneManager.GetActiveScene().name;
                SceneManager.LoadScene(currentScene);
                break;

            case "Finish":
                SceneManager.LoadScene(Train2Scene); // Or Train1Scene based on your logic
                break;
        }
    }
}
