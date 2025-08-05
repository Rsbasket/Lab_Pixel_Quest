using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;


public class HHQscript : MonoBehaviour
{
    int var = 3;
    public int speed = 9;
    public string Train1Scene = "Scene_2";
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
                SceneManager.LoadScene(nextLeveltwo);
                break;

        }
    }
}