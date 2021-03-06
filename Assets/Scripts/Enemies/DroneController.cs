﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DroneController : MonoBehaviour, IDamageable
{
    [Header("Patrol Options")]
    [SerializeField] Transform[] patrolPoints;
    int destPoint = 0; 
    NavMeshAgent agent;

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

        AudioManager.Instance.Play("DroneHover");

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
        AudioManager.Instance.Play("DroneDeath");
        Destroy(deathPS, 0.5F);
        Destroy(gameObject);        
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f) GoToNextPoint();
    }    
}
