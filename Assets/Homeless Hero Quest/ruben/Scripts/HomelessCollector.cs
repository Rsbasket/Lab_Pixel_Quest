using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HomelessCollector : MonoBehaviour
{
    public int homelessCount = 0;

    public TextMeshProUGUI counterText;
    public TextMeshProUGUI timerText;

    private float timer = 60f;
    private bool timerRunning = true;

    void Start()
    {
        UpdateCounterUI();
        UpdateTimerUI();
    }

    void Update()
    {
        if (timerRunning)
        {
            timer -= Time.deltaTime;

            if (timer <= 0f)
            {
                timer = 0f;
                timerRunning = false;
                EndGame();
            }

            UpdateTimerUI();
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Homeless"))
        {
            Destroy(other.gameObject);
            homelessCount++;
            UpdateCounterUI();
        }
    }

    void UpdateCounterUI()
    {
        if (counterText != null)
            counterText.text = homelessCount.ToString();
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = Mathf.Ceil(timer).ToString();
    }

    void EndGame()
    {
        // Save the score to pass it to the next scene
        PlayerPrefs.SetInt("HomelessCount", homelessCount);

        // Load the ResultsScene
        SceneManager.LoadScene("ResultsScene");
    }
}
