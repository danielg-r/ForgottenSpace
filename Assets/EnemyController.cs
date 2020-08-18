using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    //Este codigo esta muy desordenado, meper d0nas
    //[SerializeField] float lookRadius = 5f;
    //[SerializeField] PlayerMovement player;

    NavMeshAgent agent;
    EnemyState state;
    Animator animator;
    Rigidbody rb;
    [SerializeField] protected Transform target;
    [SerializeField] float followDistance = 8f, attackDistance = 2f;

    float distance;
    [SerializeField] int lives;
    [SerializeField] int deathTimer;

    Vector3 lastPosition;


    public virtual void Start()
    {        
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //enemy = GetComponent<Enemy>();
        FindTarget();
        state = EnemyState.Wander;
        lastPosition = transform.position;       
    }

    void Update()
    { 
        Patrol();    
    }

    #region PathfindingLogic
    public void Patrol()
    {
        //FindTarget();
        if (target != null) distance = Vector3.Distance(target.position, transform.position);
        switch (state)
        {
            default:
            case EnemyState.Wander:
                Debug.Log("Enemy Wandering");
                animator.SetBool("Attack",  false);
                if (distance < followDistance && target != null)
                {
                    state = EnemyState.Chase;
                }
                break;
            
            case EnemyState.Chase:
                Debug.Log("Enemy Chasing");
                animator.SetFloat("Speed", 1f);
                animator.SetBool("IsWalking",  true);
                agent.SetDestination(target.position);
                agent.isStopped = false;
                agent.stoppingDistance = 1.8f;
                if (distance < attackDistance) state = EnemyState.Attack;
                else if (distance > followDistance) state = EnemyState.BackToStart;
                break;
            
            case EnemyState.BackToStart:
                Debug.Log("Enemy Back to Start");
                animator.SetBool("Attack",  false);
                agent.SetDestination(lastPosition);
                agent.stoppingDistance = 0.1f; 
                if (Vector3.Distance(transform.position, lastPosition) < 0.5f)
                {
                    animator.SetFloat("Speed", 0.2f);
                    animator.SetBool("IsWalking", false);

                    state = EnemyState.Wander;
                }
            break;
            case EnemyState.Attack:
                //enemy.Attack();
                agent.isStopped = true;
                animator.SetBool("IsWalking",  false);
                animator.SetInteger("attackSelector", Random.Range(0,2));
                animator.SetBool("Attack", true);
                Debug.Log("Enemy Attacking");
                if (distance > attackDistance) state = EnemyState.Chase;
            break;
        }        
    }

    public void FindTarget()
    {        
        if (Player.Instance != null)
        {
            target = Player.Instance.transform;
        }
        else {return;}
    }

    #endregion

    void Die()
    {
        animator.SetBool("IsDead", true);
        lives--;
        if (lives > 0) StartCoroutine("DeathTimer");
        else 
        {
            agent.enabled = false;
            //Desactivar colliders etc
            this.enabled = false; 
        }
    }

    IEnumerator DeathTimer()
    {
        agent.enabled = false;
        yield return new WaitForSeconds(deathTimer);
        animator.SetBool("IsDead", false);
        animator.SetTrigger("GetUp");
        agent.enabled = true;
        state = EnemyState.Wander;
    }

    void Attack()
    {
        //Llamar al TakeDamage() del jugador o lo que sea xd
    }

    void StopAttack()
    {
        animator.SetBool("Attack", false);
    }
}

public enum EnemyState
{
    Wander,
    Chase,
    Attack,
    BackToStart
}