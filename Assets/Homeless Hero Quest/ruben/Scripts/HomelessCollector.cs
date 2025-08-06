using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class HomelessCollector : MonoBehaviour
{
    public TextMeshProUGUI counterText;
    public TextMeshProUGUI timerText;

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
            // Use GameManager's timer
            GameManager.Instance.timer -= Time.deltaTime;

            if (GameManager.Instance.timer <= 0f)
            {
                GameManager.Instance.timer = 0f;
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

            // Update the count in GameManager
            GameManager.Instance.homelessCount++;

            UpdateCounterUI();
        }
    }

    void UpdateCounterUI()
    {
        if (counterText != null)
            counterText.text = GameManager.Instance.homelessCount.ToString();
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
            timerText.text = Mathf.Ceil(GameManager.Instance.timer).ToString();
    }

    void EndGame()
    {
        PlayerPrefs.SetInt("HomelessCount", GameManager.Instance.homelessCount);
        SceneManager.LoadScene("ResultsScene");
    }
}
