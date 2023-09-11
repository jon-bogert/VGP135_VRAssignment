using TMPro;
using UnityEngine;

public class ScoreText : MonoBehaviour
{
    TMP_Text scoreText;
    GameManager gameManager;

    private void Awake()
    {
        scoreText = GetComponent<TMP_Text>();
        if (!scoreText)
            Debug.LogError("ScoreText -> Could not find Text Component");
    }

    private void Start()
    {
        gameManager  = GameManager.instance;
        if (!gameManager)
            Debug.LogError("ScoreText->Could not find GameManager in Scene");

        gameManager.scoreAdded += OnScoreUpdate;
        OnScoreUpdate(gameManager.Score);
    }

    private void OnDestroy()
    {
        gameManager.scoreAdded -= OnScoreUpdate;
    }

    void OnScoreUpdate(ulong score)
    {
        scoreText.text = "Score: " + score;
    }
}
