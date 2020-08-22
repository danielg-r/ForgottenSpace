using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IDamageable
{
    //Este codigo esta muy desordenado, meper d0nas
        //ÑO... pirata :p
    //[SerializeField] float lookRadius = 5f;
    //[SerializeField] PlayerMovement player;

    NavMeshAgent agent;
    EnemyState state;
    Animator animator;
    Rigidbody rb;
    [SerializeField] protected Transform target;
    [SerializeField] float followDistance = 8f, attackDistance = 2f;

    float distance;
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] int lives;
    [SerializeField] int deathTimer;
    [SerializeField] Collider deathCollider;

    Vector3 lastPosition;
    
    public virtual void Start()
    {        
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        FindTarget();
        state = EnemyState.Wander;
        lastPosition = transform.position;       
        currentHealth = maxHealth;
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
                //Attack();
                agent.isStopped = true;
                animator.SetBool("IsWalking",  false);
                animator.SetInteger("attackSelector", Random.Range(0,2));
                animator.SetBool("Attack", true);
                Debug.Log("Enemy Attacking");
                
                break;
            case EnemyState.Dead:
                agent.isStopped = true;
                float t = 0;
                t+= Time.deltaTime;
                if (t > 1f) agent.enabled = false;                
                break;
        }        
    }

    public void FindTarget()
    {        
        if (PlayerLife.Instance != null)
        {
            target = PlayerLife.Instance.transform;
        }
        else {return;}
    }

    #endregion

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        //lastState = state; 
        state = EnemyState.Dead;
        animator.SetBool("IsDead", true);
        lives--;
        if (lives > 0) StartCoroutine("DeathTimer");
        else 
        {
            //agent.enabled = false;
            //Sistema de particulas destrucción
            Destroy(transform.parent.gameObject);
            this.enabled = false; 
        }
    }

    IEnumerator DeathTimer()
    {
        deathCollider.enabled = false;        
        yield return new WaitForSeconds(deathTimer);
        animator.SetBool("IsDead", false);
        animator.SetTrigger("GetUp");
        currentHealth = maxHealth;
        agent.enabled = true;
        yield return new WaitForSeconds(3f);
        state = EnemyState.Wander;
        deathCollider.enabled = true;
    }

    void Attack()
    {
        PlayerLife.Instance.TakeDamage(20); //de min 0 a 100 max
    }

    void StopAttack()
    {
        animator.SetBool("Attack", false);
    }

    void ResumeChase()
    {
        if (distance > attackDistance) state = EnemyState.Chase;
    }
}

public enum EnemyState
{
    Wander,
    Chase,
    Attack,
    Dead,
    BackToStart
}