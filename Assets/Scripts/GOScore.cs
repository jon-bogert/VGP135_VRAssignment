using TMPro;
using UnityEngine;

public class GOScore : MonoBehaviour
{
    [SerializeField] TMP_Text score;
    [SerializeField] TMP_Text highScore;

    private void Start()
    {
        GameManager gm = GameManager.instance;
        score.text = "Your Score: " + gm.Score;
        highScore.text = "High Score: " + gm.HighScore;
    }
}
