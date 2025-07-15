using UnityEngine;
using UnityEngine.SceneManagement;

public class GeoQScript : MonoBehaviour
{
    int var = 3;
    public int speed = 9;
    public string nextLevel = "Scene_2";
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
                SceneManager.LoadScene(nextLevel);
                break;
        }
    }
}