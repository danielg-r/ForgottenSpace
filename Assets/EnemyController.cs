using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] float lookRadius = 5f;
    [SerializeField] PlayerMovement player;

    NavMeshAgent agent;
    EnemyState state;
    Animator animator;
    Rigidbody rb;
    //protected Enemy enemy;
    [SerializeField] protected Transform target;
    //[SerializeField] protected Transform lastPatrolpoint;
    //[SerializeField] protected int patrolwaitSeconds;
    [SerializeField] float followDistance = 8f, attackDistance = 2f;

    float distance;

    Vector3 lastPosition;


    public virtual void Start()
    {        
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        //enemy = GetComponent<Enemy>();
        //FindTarget();
        state = EnemyState.Wander;
        animator.SetFloat("Speed", 0.2f); 
        lastPosition = transform.position;       
    }

    void Update()
    { 
        Patrol();      
    }

    // IEnumerator PatrolWait ()
    // {
    //     animator.SetFloat("Speed", 0f);
    //     Debug.Log("Conteo iniciado");
    //     path.Pause();
    //     yield return new WaitForSeconds(patrolwaitSeconds);
    //     path.Play();
    //     animator.SetFloat("Speed", 0.2f);
    // }

    // void MyCallback(int waypointIndex)
    // {
    //     if (waypointIndex >= 0)
    //     {
    //         Debug.Log("Iniciando conteo");
    //         StartCoroutine(PatrolWait());
    //     }
    // }

    public void Patrol()
    {
        //FindTarget();
        if (target != null) distance = Vector3.Distance(target.position, transform.position);
        switch (state)
        {
            default:
            case EnemyState.Wander:
                animator.SetBool("Attack",  false);
                if (distance < followDistance && target != null)
                {
                    state = EnemyState.Chase;
                }
                break;
            
            case EnemyState.Chase:
                animator.SetFloat("Speed", 1f);
                animator.SetBool("Attack",  false);
                agent.SetDestination(target.position);
                agent.stoppingDistance = 1f;
                if (distance < attackDistance) state = EnemyState.Attack;
                else if (distance > followDistance) state = EnemyState.BackToStart;
                break;
            
            case EnemyState.BackToStart:
                animator.SetBool("Attack",  false);
                agent.SetDestination(lastPosition);
                agent.stoppingDistance = 0.1f; 
                if (Vector3.Distance(transform.position, lastPosition) < 0.5f)
                {
                    animator.SetFloat("Speed", 0.2f);
                    state = EnemyState.Wander;
                }
            break;
            case EnemyState.Attack:
            //enemy.Attack();
            if (distance > attackDistance) state = EnemyState.Chase;
            break;
        }        
    }

    // public void FindTarget()
    // {        
    //     if (PlayerMovement.Instance != null && PlayerMovement.Instance.canBeChased)
    //     {
    //         target = PlayerMovement.Instance.transform;
    //     }
    //     else {return;}
    // }
}

public enum EnemyState
{
    Wander,
    Chase,
    Attack,
    BackToStart
}