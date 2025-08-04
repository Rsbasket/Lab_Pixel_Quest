using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Travel : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("TeleportRoom"))
        {
            transform.position = other.transform.Find("Teleport").transform.position;
        }
    }
}


