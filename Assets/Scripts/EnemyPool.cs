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
    public int enemyAmount = 4;
    [HideInInspector]
    public int enemiesLeft;

    private List<Transform> spawnPoints;

    void Start()
    {
        objects = new List<EnemyController>();
        spawnPoints = new List<Transform>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject enemy = Instantiate(enemyPrefab);
            enemy.SetActive(false);

            objects.Add(enemy.GetComponent<EnemyController>());
        }

        GameObject[] gObjects = GameObject.FindGameObjectsWithTag("Spawn");
        for (int i = 0; i < gObjects.Length; i++)
        {
            spawnPoints.Add(gObjects[i].GetComponent<Transform>());
        }

        StartWave();
    }

    public EnemyPool(List<EnemyController> objects) : base(objects)
    {
    }

    public void StartWave()
    {
        OnReset();
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
