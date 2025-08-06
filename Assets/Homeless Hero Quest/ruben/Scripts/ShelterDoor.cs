using UnityEngine;

public class ShelterDoor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Touched by: " + other.name);

        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with shelter.");
            DepositHomeless();
        }
    }

    void DepositHomeless()
    {
        int carried = GameManager.Instance.homelessCount;

        if (carried > 0)
        {
            GameManager.Instance.totalDelivered += carried;
            GameManager.Instance.homelessCount = 0;
            Debug.Log("Delivered " + carried + " homeless people to the shelter.");
        }
        else
        {
            Debug.Log("Player has no homeless people to deliver.");
        }
    }
}
