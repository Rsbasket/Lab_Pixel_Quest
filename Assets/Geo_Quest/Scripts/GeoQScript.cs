
using UnityEngine;

public class GeoQScript : MonoBehaviour {
    int var = 3;
    public int speed = 3;

    private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();




    }

    // Update is called once per frame
    void Update()
    {
        float xInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(xInput * speed, rb.velocity.y);
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Trigger Hit");
    }

   
}

