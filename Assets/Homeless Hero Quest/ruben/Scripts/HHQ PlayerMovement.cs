using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHQscript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float verticalSpeed = 3f;
    private HHQPlayerPickup Pickup;
    private Rigidbody2D rb;

    private void Start()
    {
        Pickup = GetComponent<HHQPlayerPickup>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);


        HandlePlayerFlip(horizontalInput);


        HandleVerticalMovement();
    }


    private void HandlePlayerFlip(float horizontalInput)
    {
        if (horizontalInput < 0)
        {
            Pickup.facingLeft = true;
            transform.localScale = new Vector3(-1, 1, 1);
        }
        else if (horizontalInput > 0)
        {
            Pickup.facingLeft = false;
            transform.localScale = new Vector3(1, 1, 1);
        }
    }


    private void HandleVerticalMovement()
    {
        float verticalInput = 0f;

        if (Input.GetKey(KeyCode.W))
        {
            verticalInput = 1f;
        }
        else if (Input.GetKey(KeyCode.S))
        {
            verticalInput = -1f;
        }


        rb.velocity = new Vector2(rb.velocity.x, verticalInput * verticalSpeed);
    }
}