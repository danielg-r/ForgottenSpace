using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DroneDetection : MonoBehaviour
{
    [SerializeField] DroneSpawner[] spawners; // = FindObjectsOfType(typeof(DroneSpawner)) as DroneSpawner[];
    [SerializeField] float detectionCooldown;
    [SerializeField] bool canDetectPlayer;
    List<float> distances = new List<float>();

    void Start()
    {
        spawners = FindObjectsOfType(typeof(DroneSpawner)) as DroneSpawner[];
        canDetectPlayer = true;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && canDetectPlayer)
        {
            canDetectPlayer = false;
            GetClosestSpawner();
            StartCoroutine("DetectionCooldown");
            Debug.Log("Jugador detectado");
        }        
    }

    IEnumerator DetectionCooldown()
    {
        yield return new WaitForSeconds(detectionCooldown);
        canDetectPlayer = true;
        StopCoroutine("DetectionCooldown");
    }

    void GetClosestSpawner()
    {
        float min = 100f;
        int index = 0;
        for (int i = 1; i < spawners.Length - 1; i++)
        {
            distances[i] = spawners[i].GetDistance();
            if (distances[i] < min)
            {
                min = distances[i];
                index = i;
            }
        }
        spawners[index].StartCoroutine("SpawnDrones");
    }



    
}
