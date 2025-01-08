using UnityEngine;
using TMPro;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [SerializeField] private TMP_Text scoreText; // Text for displaying the score
    [SerializeField] private TMP_Text feedbackText; // Text for temporary messages like "Invalid command!"
    [SerializeField] private GameObject[] hearts; // Array of heart icons
    [SerializeField] private TMP_Text gameOverText; // Text for the "Game Over" message

    private void Awake()
    {
        // Singleton pattern to ensure only one UIManager exists
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void UpdateScore(int score)
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
    }

    public void InitializeUI()
    {
        UpdateScore(0); // Set score to 0 at the start
        UpdateLives(GameManager.Instance.GetLives()); // Update lives display
    }


    public void UpdateLives(int lives)
    {
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].SetActive(i < lives); // Show only the active hearts
        }
    }

    public void DisplayGameOver()
    {
        if (gameOverText != null)
        {
            gameOverText.gameObject.SetActive(true); // Show "Game Over"
        }
    }

    public void DisplayMessage(string message)
    {
        if (feedbackText != null)
        {
            feedbackText.text = message; // Set the message text
            StartCoroutine(ClearMessageAfterDelay());
        }
    }

    private IEnumerator ClearMessageAfterDelay()
    {
        yield return new WaitForSeconds(3f); // Show message for 3 seconds
        if (feedbackText != null)
        {
            feedbackText.text = ""; // Clear the feedback text
        }
    }
}
