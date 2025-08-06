using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class ResultsScreen : MonoBehaviour
{
    public TextMeshProUGUI resultsText;

    void Start()
    {
        int count = PlayerPrefs.GetInt("HomelessCount", 0);
        resultsText.text = "You helped " + count + " homeless people!";
    }

    public void ReturnToStart()
    {
        SceneManager.LoadScene("Intro Scene");
    }
}

