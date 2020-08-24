using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour, IDamageable
{
    #region Variables
    NavMeshAgent agent;
    public EnemyState state;
    Animator animator;
    Rigidbody rb;
    float distance;
    [Header("PathFinding")]
    [SerializeField] protected Transform target;
    [SerializeField] float followDistance = 8f, attackDistance = 2f;
    [Header("Attributes")]
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    public int damage;
    [SerializeField] int lives;
    [SerializeField] int deathTimer;
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject hitFX;
    [Header("Attack Colliders")]
    [SerializeField] Collider deathCollider;
    [SerializeField] Collider rightCollider;
    [SerializeField] Collider leftCollider;

    Vector3 lastPosition;
    bool isAttacking;
    #endregion

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
                FindTarget();
                if (!agent.enabled)
                { 
                    agent.enabled = true;
                    agent.isStopped = false;       
                }                    
                animator.SetBool("Attack",  false);
                if (distance < followDistance && target != null)
                {
                    state = EnemyState.Chase;
                }
                break;
            
            case EnemyState.Chase:
                agent.isStopped = false;
                if (currentHealth <= 0) state = EnemyState.Dead;
                animator.SetBool("IsWalking",  true);
                if (!isAttacking && state != EnemyState.Dead) agent.SetDestination(target.position);
                agent.stoppingDistance = 1.8f;
                if (distance < attackDistance && !isAttacking) state = EnemyState.Attack;
                else if (distance > followDistance) state = EnemyState.BackToStart;
                break;
            
            case EnemyState.BackToStart:
                animator.SetBool("Attack",  false);
                agent.SetDestination(lastPosition);
                agent.stoppingDistance = 0.1f; 
                if (Vector3.Distance(transform.position, lastPosition) < 0.5f)
                {                    
                    animator.SetBool("IsWalking", false);
                    state = EnemyState.Wander;
                }
                break;
            case EnemyState.Attack:
                isAttacking = true;                
                agent.isStopped = true;
                animator.SetBool("IsWalking",  false);
                animator.SetInteger("attackSelector", Random.Range(0,2));
                animator.SetBool("Attack", true);
                if (PlayerLife.Instance.isDead)
                {
                    state = EnemyState.BackToStart;
                    target = null;
                }
                state = EnemyState.Chase;                 
                break;
            case EnemyState.Dead:
                isAttacking = false;
                animator.SetBool("IsWalking",  false);
                animator.SetBool("Attack", false);
                float t = 0;
                t+= Time.deltaTime;
                if (t > 0.05f) agent.enabled = false;                
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
        GameObject hit = Instantiate(hitFX, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
        hit.transform.localScale = Vector3.one * 0.6f;
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        agent.isStopped = true; 
        state = EnemyState.Dead;
        animator.SetBool("IsDead", true);
        lives--;
        if (lives > 0) StartCoroutine("DeathTimer");
        else 
        {
            //agent.enabled = false;
            GameObject ps = Instantiate(deathFX, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
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
        StopCoroutine("DeathTimer");
    }

    void Attack()
    {
        PlayerLife.Instance.TakeDamage(20); //de min 0 a 100 max
    }

    void StopAttack()
    {
        agent.isStopped = false;
        isAttacking = false;
        animator.SetBool("Attack", false);
        if (rightCollider.enabled || leftCollider.enabled)
        {
            rightCollider.enabled = false;
            leftCollider.enabled = false;
        }
    }

    void RightAttack()
    {
        rightCollider.enabled = true;
    }
    void LeftAttack()
    {
        leftCollider.enabled = true;
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