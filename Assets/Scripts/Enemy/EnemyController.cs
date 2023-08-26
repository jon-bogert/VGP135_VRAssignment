using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField]
    private NavMeshAgent enemy;
    [SerializeField]
    private Vector3 destination;

    private void Update()
    {
        enemy.SetDestination(destination);
    }
}
