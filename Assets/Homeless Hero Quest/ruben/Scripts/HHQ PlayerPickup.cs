using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HHQPlayerPickup : MonoBehaviour
{
    public float pickupRange = 3f;
    public Transform holdPoint;
    public KeyCode pickupKey = KeyCode.E;

    private GameObject heldObject;
    private Rigidbody2D heldRB;
    public bool facingLeft;
    private float facingMultiplier;

    void Update()
    {
        if (facingLeft)
        {
            facingMultiplier = -1f;
        }
        else { facingMultiplier = 1f; }
        if (Input.GetKeyDown(pickupKey))
        {
            if (heldObject == null)
            {
                TryPickupObject();
            }
            else
            {
                DropObject();
            }
        }

        if (heldObject != null)
        {
            MoveObject();
        }
    }

    void TryPickupObject()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position,  Vector2.right * facingMultiplier, pickupRange);
        if (hit)
        {
            Debug.Log(hit.transform.tag);
            if (hit.collider.CompareTag("Pickup"))
            {
                Debug.Log("find error");
                heldObject = hit.collider.gameObject;
                heldRB = heldObject.GetComponent<Rigidbody2D>();

                if (heldRB != null)
                {
                    heldRB.gravityScale = 0;
                    heldRB.freezeRotation = true;
                    heldRB.velocity = Vector2.zero;
                    heldRB.angularVelocity = 0f;
                    heldRB.rotation = 0f;
                }
            }
        }
    }

    void MoveObject()
    {
        Vector3 directionToPoint = holdPoint.position - heldObject.transform.position;
        float moveSpeed = 10f;

        if (heldRB != null)
        {
            heldRB.velocity = directionToPoint * moveSpeed;
        }
    }

    void DropObject()
    {
        if (heldRB != null)
        {
            heldRB.gravityScale = 1;
            heldRB.freezeRotation = false;
        }

        heldObject = null;
        heldRB = null;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, (Vector2)transform.position + (Vector2.right * facingMultiplier) * pickupRange);
    }
}