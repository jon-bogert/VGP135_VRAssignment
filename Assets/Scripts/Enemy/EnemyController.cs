using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Movement"), SerializeField]
    private NavMeshAgent enemy;
    [SerializeField]
    private Vector3 destination;
    [SerializeField]
    private Animator anim;
    [SerializeField]
    private float minDistance;

    private void Update()
    {
        if((transform.position - destination).magnitude > 0.5f)
        {
            Walking();
        }
    }

    private void Walking()
    {
        var distance = (transform.position - destination).magnitude;

        enemy.SetDestination(destination);

        if ( distance > minDistance && !anim.GetBool("IsWalking"))
        {
            anim.SetBool("IsWalking", true);
        }
        else if (distance < minDistance)
        {
            anim.SetBool("IsWalking", false);
        }
    }
}
