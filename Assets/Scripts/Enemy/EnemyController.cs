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

    [Space, Header("States"), SerializeField]
    private Enemy enemyAgent;
    [SerializeField]
    private StateMachine<EnemyController> statesMachine;
    [SerializeField]
    private EnemyStates currentState;

    private void Awake()
    {
        enemyAgent = new Enemy();
        statesMachine = new StateMachine<EnemyController>(this);
        statesMachine.AddState<EnemyIdle>();
        statesMachine.AddState<EnemySeek>();
    }

    private void Start()
    {
        ChangeState(EnemyStates.Idle);
    }

    public void Update()
    {
        statesMachine.Update(Time.deltaTime);

        StateManger();
    }

    private void StateManger()
    {
        if ((transform.position - destination).magnitude > 0.5f && currentState != EnemyStates.Seek)
        {
            ChangeState(EnemyStates.Seek);
        }
        else if((transform.position - destination).magnitude < 0.5f && currentState != EnemyStates.Idle)
        {
            ChangeState(EnemyStates.Idle);
        }
    }

    private void ChangeState(EnemyStates state)
    {
        currentState = state;
        statesMachine.ChangeState((int)currentState);
    }
}
