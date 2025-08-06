using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int homelessCount = 0;
    public int totalDelivered = 0;
    public float timer = 60f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
