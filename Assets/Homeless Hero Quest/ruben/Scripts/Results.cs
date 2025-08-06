using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultsScreen : MonoBehaviour
{
    public TextMeshProUGUI resultsText;

    void Start()
    {
        int stored = GameManager.Instance.totalDelivered;
        int stillCarrying = GameManager.Instance.homelessCount;
        int finalTotal = stored + stillCarrying;

        resultsText.text = "You helped " + finalTotal + " homeless people!";
    }

    public void ReturnToStart()
    {
        SceneManager.LoadScene("Intro Scene");
    }
}



