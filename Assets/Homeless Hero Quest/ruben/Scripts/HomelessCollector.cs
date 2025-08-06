using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class HomelessCollector : MonoBehaviour
{
    public TextMeshProUGUI counterText;  // Assign homeless counter TMP Text here
    public TextMeshProUGUI timerText;    // Assign timer TMP Text here

    private bool sceneLoading = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Homeless"))
        {
            Destroy(other.gameObject);
            GameManager.Instance.homelessCount++;
            UpdateCounterUI();
        }
    }

    void Update()
    {
        if (GameManager.Instance != null && GameManager.Instance.timer > 0f)
        {
            GameManager.Instance.timer -= Time.deltaTime;
            UpdateTimerUI();

            if (GameManager.Instance.timer <= 0f && !sceneLoading)
            {
                GameManager.Instance.timer = 0f;
                sceneLoading = true;
                SceneManager.LoadScene("ResultsScene");
            }
        }
    }

    void UpdateCounterUI()
    {
        if (counterText != null)
        {
            counterText.text = GameManager.Instance.homelessCount.ToString();
        }
    }

    void UpdateTimerUI()
    {
        if (timerText != null)
        {
            int secondsLeft = Mathf.FloorToInt(Mathf.Max(GameManager.Instance.timer, 0f));
            timerText.text = secondsLeft.ToString();
        }
    }
}
