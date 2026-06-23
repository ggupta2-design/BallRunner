using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

// The brain of the game — controls start, game over, and restart
public class GameManager : MonoBehaviour
{
    public static GameManager instance;   // Other scripts access this

    [Header("References")]
    public ObstacleSpawner spawner;
    public ScrollingBackground[] scrollers; // Drag ALL scrolling objects here
    public GameObject gameOverPanel;        // The Game Over UI panel

    private bool gameStarted = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        // Hide game over screen at start
        gameOverPanel.SetActive(false);
        StartGame();
    }

    void StartGame()
    {
        gameStarted = true;
        gameOverPanel.SetActive(false);

        // Start all scrollers
        foreach (var s in scrollers)
            s.StartScrolling();

        spawner.StartSpawning();
        ScoreManager.instance.StartCounting();
        ScoreManager.instance.ResetScore();
    }

    // Called by PlayerController when player hits obstacle
    public void GameOver()
    {
        gameStarted = false;

        // Stop everything
        foreach (var s in scrollers)
            s.StopScrolling();

        spawner.StopSpawning();
        ScoreManager.instance.StopCounting();

        // Slow-motion death effect (optional, feels good)
        Time.timeScale = 0.3f;

        // Show game over UI after a tiny delay
        Invoke("ShowGameOverPanel", 0.5f);
    }

    void ShowGameOverPanel()
    {
        Time.timeScale = 1f;  // Reset time
        gameOverPanel.SetActive(true);
    }

    // Called by the Restart button in the UI
    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
