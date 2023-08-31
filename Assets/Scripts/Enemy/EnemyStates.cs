using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { Idle, Seek, Attacking, Dying, None }
//------------------------------------------------------------------------------------------------
public class EnemyIdle : IState<EnemyController>
{
    public void Enter(EnemyController agent)
    {
        agent.anim.Play("ZombieIdle01");
    }

    public void Exit(EnemyController agent)
    {

    }

    public void Update(EnemyController agent, float deltaTime)
    {
        if (agent.enemyAgent.health.Get() <= 0)
        {
            agent.ChangeState(EnemyStates.Dying);
        }
        else if ((agent.transform.position - agent.destination).magnitude > 0.5f)
        {
            agent.ChangeState(EnemyStates.Seek);
        }
    }
}
//------------------------------------------------------------------------------------------------
public class EnemySeek : IState<EnemyController>
{

    public void Enter(EnemyController agent)
    {
        agent.anim.Play("ZombieWalk01");
    }

    public void Exit(EnemyController agent)
    {
        agent.rb.velocity = Vector3.zero;
    }

    public void Update(EnemyController agent, float deltaTime)
    {
        if (agent.enemyAgent.health.Get() <= 0)
        {
            agent.ChangeState(EnemyStates.Dying);
        }
        else if ((agent.transform.position - agent.destination).magnitude < 0.5f)
        {
            agent.ChangeState(EnemyStates.Idle);
        }

        agent.enemy.SetDestination(agent.destination);
    }
}
//------------------------------------------------------------------------------------------------
public class EnemyAttacking : IState<EnemyController>
{
    private const float attackDuration = 2.0f;
    private float attackTimer = attackDuration;

    public void Enter(EnemyController agent)
    {
        agent.anim.Play("ZombieAttack01");
    }

    public void Exit(EnemyController agent)
    {

    }

    public void Update(EnemyController agent, float deltaTime)
    {
        if (agent.enemyAgent.health.Get() <= 0)
        {
            agent.ChangeState(EnemyStates.Dying);
        }
        else if ((agent.transform.position - agent.destination).magnitude < 0.5f)
        {
            agent.ChangeState(EnemyStates.Idle);
        }
        else if ((agent.transform.position - agent.destination).magnitude > 0.5f)
        {
            agent.ChangeState(EnemyStates.Seek);
        }

        attackTimer -= deltaTime;

        if (attackTimer <= 0.0f)
        {
            attackTimer = attackDuration;
            Attack();
        }
    }

    private void Attack()
    {

    }
}
//------------------------------------------------------------------------------------------------
public class EnemyDying : IState<EnemyController>
{
    private float timer = 1.0f;
    public void Enter(EnemyController agent)
    {
        agent.anim.Play("ZombieDeath01_A");
    }

    public void Exit(EnemyController agent)
    {
        Object.Destroy(agent.gameObject);
    }

    public void Update(EnemyController agent, float deltaTime)
    {
        timer -= deltaTime;
        if (timer <= 0.0f) Exit(agent);
    }
}