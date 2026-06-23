using UnityEngine;
using TMPro;  // TextMeshPro for clean text rendering

// Tracks and displays the score (time survived)
public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;      // Drag the score UI text here
    public TextMeshProUGUI highScoreText;  // Drag the high score UI text here

    private float score = 0f;
    private float highScore = 0f;
    private bool isRunning = false;

    void Awake()
    {
        // Singleton so other scripts can call ScoreManager.instance
        instance = this;
        // Load saved high score
        highScore = PlayerPrefs.GetFloat("HighScore", 0f);
    }

    void Update()
    {
        if (!isRunning) return;

        score += Time.deltaTime;  // Score = seconds survived
        scoreText.text = "Score: " + Mathf.FloorToInt(score).ToString();
    }

    public void StartCounting() { isRunning = true; }

    public void StopCounting()
    {
        isRunning = false;

        // Save high score
        if (score > highScore)
        {
            highScore = score;
            PlayerPrefs.SetFloat("HighScore", highScore);
        }

        if (highScoreText != null)
            highScoreText.text = "Best: " + Mathf.FloorToInt(highScore).ToString();
    }

    public void ResetScore()
    {
        score = 0f;
        scoreText.text = "Score: 0";
    }
}
