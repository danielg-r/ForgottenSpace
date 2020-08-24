using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DroneDetection : MonoBehaviour
{
    [SerializeField] DroneSpawner[] spawners; // = FindObjectsOfType(typeof(DroneSpawner)) as DroneSpawner[];
    [SerializeField] float detectionCooldown;
    [SerializeField] bool canDetectPlayer;
    //float[] distances = new float [spawners.Length];
    List<float> distances = new List<float>();
    public UnityEvent OnDetection;
    float min = 100f;

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
            OnDetection.Invoke();
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
        int index = 0;
        for (int i = 0; i < spawners.Length; i++)
        {
            distances.Add(spawners[i].GetDistance()); //[i] = ;
            if (distances[i] < min)
            {
                min = distances[i];
                index = i;
            }
        }
        spawners[index].StartCoroutine("SpawnDrones");
    }



    
}
