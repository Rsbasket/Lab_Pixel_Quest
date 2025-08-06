using UnityEngine;

public class ShelterDoor : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
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
            Debug.Log("Player touched door but had no homeless people.");
        }
    }
}
