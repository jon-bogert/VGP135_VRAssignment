using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { Idle, Seek, Attacking, Dying}

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

    }
}

public class EnemySeek : IState<EnemyController>
{

    public void Enter(EnemyController agent)
    {
        agent.anim.Play("ZombieWalk01");
    }

    public void Exit(EnemyController agent)
    {

    }

    public void Update(EnemyController agent, float deltaTime)
    {
        agent.enemy.SetDestination(agent.destination);
    }
}

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
        attackTimer -= deltaTime;

        if(attackTimer <= 0.0f)
        {
            attackTimer = attackDuration;
            Attack();
        }
    }

    private void Attack()
    {

    }
}

public class EnemyDying : IState<EnemyController>
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