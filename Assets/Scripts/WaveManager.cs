using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    EnemyPool enemyPool;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string textLabel = "Wave: ";
    [SerializeField] private int enemyIncrease = 3;
    private int waveCount = 1;

    void Start()
    {
        enemyPool = GameObject.FindObjectOfType<EnemyPool>();
        //enemyPool.StartWave();
        UpdateWaveText();
    }

    public void CheckGameOver()
    {
        enemyPool.enemiesLeft--;
        if (enemyPool.AllEnemiesDead())
        {
            enemyPool.enemyAmount += enemyIncrease;
            waveCount++;
            enemyPool.StartWave();
            UpdateWaveText();
        }
    }

    void UpdateWaveText()
    {
        text.text = textLabel + waveCount.ToString();
    }
}
