using UnityEngine;
using UnityEngine.SceneManagement;

public class HomelessPickup : MonoBehaviour
{
    public GameObject homelessPrefab;
    private GameObject currentHomeless;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && currentHomeless == null)
        {
            PickupHomeless();
        }
    }

    void PickupHomeless()
    {
        // Instantiate homeless above player
        currentHomeless = Instantiate(homelessPrefab, transform.position + Vector3.up * 2f, Quaternion.identity);

        // Make homeless a child of the player to follow between scenes
        currentHomeless.transform.SetParent(transform);

        // Make sure it stays between scenes
        DontDestroyOnLoad(currentHomeless);
        DontDestroyOnLoad(gameObject); // Also make player persistent
    }
}
