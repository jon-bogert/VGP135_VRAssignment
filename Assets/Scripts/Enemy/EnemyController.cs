using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [Header("Movement")]
    public NavMeshAgent enemy;
    public Vector3 destination;
    public Animator anim;
    [SerializeField]
    private float minDistance;
    public Rigidbody rb;

    [Space, Header("States")]
    public Enemy enemyAgent;
    [SerializeField]
    private StateMachine<EnemyController> statesMachine;
    [SerializeField]
    private EnemyStates currentState = EnemyStates.None;

    private void Awake()
    {
        enemyAgent = new Enemy();
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

        StateManger();
    }

    private void StateManger()
    {

    }

    public void ChangeState(EnemyStates state)
    {
        if (currentState == state) return;

        currentState = state;
        statesMachine.ChangeState((int)currentState);
    }
}
