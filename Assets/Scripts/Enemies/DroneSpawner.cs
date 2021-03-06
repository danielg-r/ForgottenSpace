﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using DG.Tweening;

public class DroneSpawner : MonoBehaviour
{
    public float distanceToPlayer; 
    [Header("Attack Drone Spawning")]
    [SerializeField] Transform attackDroneSpawn;
    [SerializeField] GameObject attackDronePrefab;
    [SerializeField] GameObject attackDroneFX;
    //[SerializeField] int attackDroneAmount;
    [SerializeField] float spawnInterval;
    bool isSpawning;
    Vector3 positionRandomizer;
    [SerializeField] GameObject spawnerLights;

    public float GetDistance()
    {
        if (PlayerLife.Instance != null) distanceToPlayer = Vector3.Distance(transform.position, PlayerLife.Instance.transform.position);
        return distanceToPlayer;
    }

    void Update()
    {
        GetDistance();
        //Testing        
    }

    public IEnumerator SpawnDrones(int droneAmount)
    {
        spawnerLights.SetActive(true);
        for (int i = 0; i < droneAmount; i++)
        {
            positionRandomizer = new Vector3(Random.Range(-1f, 1f), 0, Random.Range(-1f, 1f));
            SpawnAttackDrone();
            yield return new WaitForSeconds(spawnInterval);
        }
        spawnerLights.SetActive(false);
        yield return new WaitForSeconds(1f);
        isSpawning = false;
        
    }

    void SpawnAttackDrone()
    {
        GameObject drone = Instantiate(attackDronePrefab, attackDroneSpawn.position + positionRandomizer, attackDroneSpawn.rotation);
        GameObject ps = Instantiate(attackDroneFX, attackDroneSpawn.position + positionRandomizer + new Vector3 (0,-1f,0), attackDroneFX.transform.rotation);
        ps.transform.localScale = Vector3.one * 0.7f;
        drone.GetComponentInChildren<NavMeshAgent>().SetDestination(PlayerLife.Instance.transform.position); 
    }
}
