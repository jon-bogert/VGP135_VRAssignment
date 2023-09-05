using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    EnemyPool enemyPool;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private int enemyIncrease = 3;
    private int waveCount = 0;

    void Start()
    {
        enemyPool = GameObject.FindObjectOfType<EnemyPool>();
    }

    public void CheckGameOver()
    {
        enemyPool.enemiesLeft--;
        if (enemyPool.AllEnemiesDead())
        {
            enemyPool.enemyAmount += enemyIncrease;
            waveCount++;
            enemyPool.StartWave();
            EnableText();
        }
    }

    void EnableText()
    {
        waveCount++;
        text.text = "Wave " + waveCount.ToString();
        text.enabled = true;
        Invoke("DisableText", 3f);
    }

    void DisableText()
    {
        text.enabled = false;
    }
}
