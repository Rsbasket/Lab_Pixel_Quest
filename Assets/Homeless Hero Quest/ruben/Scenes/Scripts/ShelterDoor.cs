using UnityEngine;

public class DoorInteraction : MonoBehaviour
{
    public GameObject itemToDrop; // The item to drop when the door is interacted with.
    public Transform dropPosition; // Position where the item will be dropped.
    public static int itemCounter = 0; // A static counter to keep track of how many items were dropped.

    private bool isPlayerInRange = false;

    void Update()
    {
        // Check if player presses 'E' and is in range of the door
        if (isPlayerInRange && Input.GetKeyDown(KeyCode.E))
        {
            InteractWithDoor();
        }
    }

    private void InteractWithDoor()
    {
        // Drop the item
        if (itemToDrop != null && dropPosition != null)
        {
            Instantiate(itemToDrop, dropPosition.position, dropPosition.rotation);
        }

        // Increment the counter
        itemCounter++;

        // Optionally, disable the door or perform other actions
        Debug.Log("Item dropped! Total items dropped: " + itemCounter);

        // You could add functionality to disable the door after interaction or change its state
        // For example:
        // gameObject.SetActive(false); // This disables the door.
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true; // Player is within interaction range
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false; // Player is out of interaction range
        }
    }
}
