using UnityEngine;
using UnityEngine.AI;

public enum EnemyStates { Idle, Seek, Attacking, Dying, None }
//------------------------------------------------------------------------------------------------
public class EnemyIdle : IState<EnemyController>
{
    Vector3 zero = Vector3.zero;

    public void Enter(EnemyController agent)
    {
        agent.anim.Play("ZombieIdle01");
    }

    public void Exit(EnemyController agent)
    {

    }

    public void Update(EnemyController agent, float deltaTime)
    {
        if (agent.isDead)
        {
            agent.ChangeState(EnemyStates.Dying);
        }
        else if (agent.target && (agent.transform.position - agent.target.transform.position).magnitude > agent.stopingLength)
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
        agent.enemy.speed = agent.moveSpeed;
        agent.anim.Play("ZombieWalk01");
    }

    public void Exit(EnemyController agent)
    {
        agent.enemy.speed = 0.0f;
        agent.enemy.angularSpeed = 0.0f;
        agent.rb.velocity = Vector3.zero;
    }

    public void Update(EnemyController agent, float deltaTime)
    {
        if (agent.isDead)
        {
            agent.ChangeState(EnemyStates.Dying);
        }
        else if (!agent.target)
        {
            agent.ChangeState(EnemyStates.Idle);
        }
        else if((agent.transform.position - agent.target.transform.position).magnitude < agent.stopingLength)
        {
            agent.ChangeState(EnemyStates.Attacking);
        }

        agent.enemy.SetDestination(agent.target.transform.position);
    }
}
//------------------------------------------------------------------------------------------------
public class EnemyAttacking : IState<EnemyController>
{
    private const float attackDuration = 1.35f;
    private float attackTimer = 0.2f;
    public Vector3 pos;
    public Vector3 offset = new Vector3(0.0f, 1.0f, 0.0f);

    public void Enter(EnemyController agent)
    {
        agent.anim.Play("ZombieAttack01");
    }

    public void Exit(EnemyController agent)
    {

    }

    public void Update(EnemyController agent, float deltaTime)
    {
        agent.enemy.speed = 0.0f;
        agent.enemy.angularSpeed = 0.0f;

        if (agent.isDead)
        {
            agent.ChangeState(EnemyStates.Dying);
        }
        else if (!agent.target)
        {
            agent.ChangeState(EnemyStates.Idle);
        }
        else if ((agent.transform.position - agent.target.transform.position).magnitude > agent.stopingLength)
        {
            agent.ChangeState(EnemyStates.Seek);
        }

        attackTimer -= deltaTime;

        if (attackTimer <= 0.0f)
        {
            attackTimer = attackDuration;
            Attack(agent);
        }
    }

    private void Attack(EnemyController agent)
    {
        var pos = agent.transform.position + offset + agent.transform.forward * agent.distance;
        Collider[] colliders = Physics.OverlapSphere(pos, agent.radius);

        foreach (Collider collider in colliders)
        {
            if (collider.CompareTag("Player"))
            {
                //collider.GetComponent<Health>().Damage(10);
                break;
            }
        }
    }
}
//------------------------------------------------------------------------------------------------
public class EnemyDying : IState<EnemyController>
{
    private WaveManager manager;
    private float timer = 1.0f;

    public void Enter(EnemyController agent)
    {
        agent.anim.Play("ZombieDeath01_A");
    }

    public void Exit(EnemyController agent)
    {
        manager = GameObject.FindObjectOfType<WaveManager>();
        manager.CheckGameOver();
        agent.gameObject.SetActive(false);
    }

    public void Update(EnemyController agent, float deltaTime)
    {
        timer -= deltaTime;
        if (timer <= 0.0f)
            agent.ChangeState(EnemyStates.Idle);
    }
}