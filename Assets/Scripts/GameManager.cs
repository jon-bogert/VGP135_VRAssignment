using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void ScoreEvent(ulong score);

public class GameManager : MonoBehaviour
{
    ulong score = 0;
    ulong highScore = 0;

    public ulong Score { get { return score; } }
    public ulong HighScore { get { return highScore; } }

    public ScoreEvent scoreAdded;

    private void Awake()
    {
        if (FindObjectsOfType<GameManager>().Length > 1)
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);
        Application.targetFrameRate = 120;
    }

    public void AddToScore(uint amt)
    {
        score += amt;
        scoreAdded?.Invoke(score);
    }

    public void GameOver()
    {
        if (score > highScore)
            highScore = score;

        score = 0;
        LoadGameOver();
    }

    private void LoadGameOver()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadGame()
    {
        SceneManager.LoadScene("Game");
    }
}