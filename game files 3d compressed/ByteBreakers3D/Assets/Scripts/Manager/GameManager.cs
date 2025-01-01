using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    private int score = 0;
    private int lives = 3; // Player starts with 3 lives


    private void Start()
    {
        UIManager.Instance.InitializeUI(); // Initialize the UI at the start
    }


    private void Awake()
    {
        // Singleton pattern to ensure only one GameManager exists
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    public void AddScore(int amount)
    {
        score += amount;
        UIManager.Instance.UpdateScore(score);
    }

    public void ReduceLives()
    {
        lives--;

        UIManager.Instance.UpdateLives(lives);

        if (lives <= 0)
        {
            GameOver();
        }
    }

    public int GetLives()
    {
        return lives; // Return the current lives count
    }



    private void GameOver()
    {
        Time.timeScale = 1f; // Ensure time is not paused when transitioning
        UnityEngine.SceneManagement.SceneManager.LoadScene("GameOverScene");
    }

}
