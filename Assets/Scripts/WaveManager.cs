using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    EnemyPool enemyPool;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] private int enemyIncrease = 3;
    private int waveCount = 1;

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
        }
    }
}
