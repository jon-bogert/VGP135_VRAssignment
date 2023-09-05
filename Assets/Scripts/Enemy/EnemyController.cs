using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public NavMeshAgent enemy;
    public GameObject target;
    public float targetSize;
    public Animator anim;
    public Rigidbody rb;

    [Space, Header("States")]
    public Health health;
    [SerializeField]
    private StateMachine<EnemyController> statesMachine;
    [SerializeField]
    private EnemyStates currentState = EnemyStates.None;

    private void Awake()
    {
        statesMachine = new StateMachine<EnemyController>(this);
        statesMachine.AddState<EnemyIdle>();
        statesMachine.AddState<EnemySeek>();
        statesMachine.AddState<EnemyAttacking>();
        statesMachine.AddState<EnemyDying>();
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChangeState(EnemyStates.Idle);
    }

    public void Update()
    {
        statesMachine.Update(Time.deltaTime);
    }

    public void ChangeState(EnemyStates state)
    {
        if (currentState == state) return;

        currentState = state;
        statesMachine.ChangeState((int)currentState);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position + (Vector3.forward) + new Vector3(0.0f, 1.0f, 0.0f), 1);
    }
}