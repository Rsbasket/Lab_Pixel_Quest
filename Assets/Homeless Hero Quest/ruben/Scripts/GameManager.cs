using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int homelessCount = 0;       // Number currently carried
    public int totalDelivered = 0;      // Number dropped off at shelters
    public float timer = 60f;           // Shared timer across scenes

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Persist between scenes
        }
        else
        {
            Destroy(gameObject); // Prevent duplicates
        }
    }
}
