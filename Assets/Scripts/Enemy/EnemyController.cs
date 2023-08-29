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
        statesMachine.AddState<EnemyAttacking>();
        statesMachine.AddState<EnemyDying>();
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
        if(enemyAgent.health.Get() <= 0)
        {
            ChangeState(EnemyStates.Dying);
        }
        else if ((transform.position - destination).magnitude > 0.5f)
        {
            ChangeState(EnemyStates.Seek);
        }
        else if((transform.position - destination).magnitude < 0.5f)
        {
            ChangeState(EnemyStates.Idle);
        }
    }

    private void ChangeState(EnemyStates state)
    {
        if (currentState == state) return;

        currentState = state;
        statesMachine.ChangeState((int)currentState);
    }
}
