using UnityEngine;
using TMPro;

public class WaveManager : MonoBehaviour
{
    EnemyPool enemyPool;

    [SerializeField] TextMeshProUGUI text;
    [SerializeField] string textLabel = "Wave: ";
    [SerializeField] private int enemyIncrease = 3;
    [SerializeField] private GameObject ammoPrefab;

    [SerializeField, Range(0, 100)]
    private double ammoDropChance = 25;
    
    private int waveCount = 1;

    private static System.Random rnd = new System.Random();

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

    public void AmmoDropCheck(EnemyController agent)
    {
        double val = rnd.NextDouble() * 100;

        if (val <= ammoDropChance)
        {
            Instantiate(ammoPrefab, agent.transform.position, Quaternion.identity);
        }
    }

    void UpdateWaveText()
    {
        text.text = textLabel + waveCount.ToString();
    }
}
