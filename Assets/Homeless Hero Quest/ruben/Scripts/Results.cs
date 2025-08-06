using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultsScreen : MonoBehaviour
{
    public TextMeshProUGUI resultsText;

    void Start()
    {
        int stored = GameManager.Instance.totalDelivered;

        resultsText.text = "You brought " + stored + " homeless people to the Shelter!";
    }

    public void ReturnToStart()
    {
        SceneManager.LoadScene("Intro Scene");
    }
}



