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
    [SerializeField] LayerMask playerMask;


    Transform lastPosition;
    bool isAttacking;
    bool playerDetected;
    AudioSource overloadSound;

    public float FollowDistance { get => followDistance; set => followDistance = value; }
    #endregion

    public virtual void Start()
    {        
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        FindTarget();
        state = EnemyState.Wander;
        lastPosition = transform;       
        currentHealth = maxHealth;
        playerDetected = false;
        overloadSound = GetComponent<AudioSource>();
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
                if (playerDetected) state = EnemyState.Chase;
                FindTarget();
                //playerDetected = false;
                if (!agent.enabled)
                { 
                    agent.enabled = true;
                    agent.isStopped = false;       
                }                    
                animator.SetBool("Attack",  false);
                break;
            
            case EnemyState.Chase:
                agent.isStopped = false;
                if (currentHealth <= 0) state = EnemyState.Dead;
                animator.SetBool("IsWalking",  true);
                FindTarget(); 
                if (!isAttacking && state != EnemyState.Dead) agent.SetDestination(target.position);
                agent.stoppingDistance = 1.2f;
                if (distance < attackDistance && !isAttacking) state = EnemyState.Attack;
                else if (distance > followDistance) state = EnemyState.BackToStart;
                break;
            
            case EnemyState.BackToStart:
                playerDetected = false;
                animator.SetBool("Attack",  false);
                agent.SetDestination(lastPosition.position);
                agent.stoppingDistance = 0.1f; 
                if (Vector3.Distance(transform.position, lastPosition.position) < 0.5f)
                {                    
                    animator.SetBool("IsWalking", false);
                    state = EnemyState.Wander;
                    transform.rotation = lastPosition.rotation;
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
                }
                state = EnemyState.Chase;                 
                break;
            case EnemyState.Dead:
                agent.isStopped = true; 
                isAttacking = false;
                animator.SetBool("IsWalking",  false);
                animator.SetBool("Attack", false);
                float t = 0;
                t+= Time.deltaTime;
                //if (t > 0.05f) agent.enabled = false;                
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
        hit.transform.parent = transform;
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        agent.enabled = true;
        //agent.isStopped = true; 
        
        agent.isStopped = true; 
        state = EnemyState.Dead;
        animator.SetBool("IsDead", true);
        lives--;
        if (lives > 0) StartCoroutine("DeathTimer");
        else 
        {
            //agent.enabled = false;
            Collider[] hitPlayer = Physics.OverlapSphere(transform.position, 4f, playerMask);
            foreach (Collider col in hitPlayer)
            {
                if (col.gameObject.GetComponent<PlayerLife>() != null)
                {
                    PlayerLife.Instance.TakeDamage((int)((float)damage*1.3f));
                }
            }
            GameObject ps = Instantiate(deathFX, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
            Destroy(ps, 0.5f);
            Destroy(transform.parent.gameObject);
            this.enabled = false; 
        }
    }

    IEnumerator DeathTimer()
    {
        AudioManager.Instance.Play("RobotStun");
        deathCollider.enabled = false;        
        yield return new WaitForSeconds(deathTimer);
        animator.SetBool("IsDead", false);
        animator.SetTrigger("GetUp");
        if (overloadSound != null) StartCoroutine("OverloadSound");
        currentHealth = maxHealth;
        agent.enabled = true;
        yield return new WaitForSeconds(2.5f);
        state = EnemyState.Wander;
        deathCollider.enabled = true;
        agent.speed *= 1.1f;
        StopCoroutine("DeathTimer");
    }

    IEnumerator OverloadSound()
    {
        overloadSound.Play();
        yield return new WaitForSeconds(overloadSound.clip.length);
        Die();
    }

    public void PlayerDetected()
    {
        if (!playerDetected)
        {
            state = EnemyState.Chase;
            AudioManager.Instance.Play("RobotDetect");
            playerDetected = true;
        }
    }

    void Attack()
    {
        PlayerLife.Instance.TakeDamage(20); //de min 0 a 100 max
    }

    void StopAttack()
    {
        //agent.isStopped = false;         Esto causaba el error random cuando moría en el ataque
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

public enum EnemyState { Wander, Chase,Attack, Dead, BackToStart }