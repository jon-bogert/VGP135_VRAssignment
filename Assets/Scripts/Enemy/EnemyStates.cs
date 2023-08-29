using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { Idle, Seek, Attacking}

public class EnemyIdle : IState<EnemyController>
{
    public void Enter(EnemyController agent)
    {

    }

    public void Exit(EnemyController agent)
    {

    }

    public void Update(EnemyController agent, float deltaTime)
    {

    }
}

public class EnemySeek : IState<EnemyController>
{

    public void Enter(EnemyController agent)
    {
        agent.anim.SetBool("IsWalking", true);
    }

    public void Exit(EnemyController agent)
    {
        agent.anim.SetBool("IsWalking", false);
    }

    public void Update(EnemyController agent, float deltaTime)
    {
        agent.enemy.SetDestination(agent.destination);
    }
}

public class EnemyAttacking : IState<EnemyController>
{
    public void Enter(EnemyController agent)
    {

    }

    public void Exit(EnemyController agent)
    {

    }

    public void Update(EnemyController agent, float deltaTime)
    {

    }
}