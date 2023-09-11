using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XephTools;

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
        Debug.Log("<color=green>Start Wave");
        Debug.Log("Enemy Amount: " + enemyAmount);
        Debug.Log("Enemies Left Amount: " + enemiesLeft);
        //OnReset();
        for (int i = 0; i < enemyAmount; i++)
        {
            EnemyController next = GetNext();
            next.gameObject.SetActive(true);
            next.transform.position = spawnPoints[i % spawnPoints.Count].position;
            //objects[i].gameObject.SetActive(true);
            //objects[i].transform.position = spawnPoints[i % spawnPoints.Count].position;
        }
        enemiesLeft = enemyAmount;
    }

    public bool AllEnemiesDead()
    {
        return enemiesLeft <= 0;
    }

    private void Update()
    {
        VRDebug.Monitor(2, "Amt  " + enemyAmount.ToString());
        VRDebug.Monitor(1, "Left " + enemiesLeft.ToString());
    }
}
