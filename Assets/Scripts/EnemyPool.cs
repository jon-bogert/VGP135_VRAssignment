using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class EnemyPool : Pool<EnemyController>
{
    [SerializeField]
    private int poolSize = 50;
    [SerializeField]
    private GameObject enemyPrefab;
    private int enemyAmount;
    public int enemiesLeft;

    private List<Transform> spawnPoints;

    void Start()
    {
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);

            objects.Add(enemy.GetComponent<EnemyController>());
        }
    }

    public EnemyPool(List<EnemyController> objects) : base(objects)
    {
    }

    public void StartWave()
    {
        Reset();
        for (int i = 0; i < enemyAmount; i++)
        {
            objects[i].gameObject.SetActive(true);
            objects[i].transform.position = spawnPoints[i % spawnPoints.Count].position;
        }
        enemiesLeft = enemyAmount;
    }

    public bool AllEnemiesDead()
    {
        return enemiesLeft > 0;
    }
}
