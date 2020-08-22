using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneController : MonoBehaviour, IDamageable
{
    [Header("Patrol Options")]
    [SerializeField] Transform[] patrolPoints;
    int destPoint = 0; 
    NavMeshAgent agent;
    [Header("Attack Drone Spawning")]
    [SerializeField] Transform attackDroneSpawn;
    [SerializeField] GameObject attackDronePrefab;
    [SerializeField] int attackDroneAmount;
    [SerializeField] float spawnInterval;
    bool isSpawning;

    [SerializeField] float maxHealth; 
    [SerializeField] float currentHealth; 
    [SerializeField] GameObject deathFX;



    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;  

        GoToNextPoint();
    }

    void GoToNextPoint()
    {
        if (patrolPoints.Length == 0) return;

        agent.destination = patrolPoints[destPoint].position;

        destPoint = (destPoint + 1) % patrolPoints.Length;
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 100) Die();
    }

    void Die()
    {
        GameObject deathPS = Instantiate(deathFX, transform.position, Quaternion.identity);
        deathPS.transform.localScale = Vector3.one * 0.5f;
        Destroy(gameObject);        
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f) GoToNextPoint();

        if (Input.GetKeyDown(KeyCode.J) && !isSpawning)
        {
            StartCoroutine("CallAttackDrones");
            isSpawning = true;
        }
    }

    IEnumerator CallAttackDrones()
    {
        for (int i = 0; i < attackDroneAmount; i++)
        {
            SpawnAttackDrone();
            yield return new WaitForSeconds(spawnInterval);
        }
        yield return new WaitForSeconds(1f);
        isSpawning = false;
    }

    void SpawnAttackDrone()
    {
        GameObject drone = Instantiate(attackDronePrefab, attackDroneSpawn.position, attackDroneSpawn.rotation);
        drone.GetComponentInChildren<NavMeshAgent>().SetDestination(PlayerLife.Instance.transform.position); 
    }
}
