using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DroneDetection : MonoBehaviour
{
    DroneSpawner[] spawners; // = FindObjectsOfType(typeof(DroneSpawner)) as DroneSpawner[];
    [SerializeField] float detectionCooldown;
    [SerializeField] bool canDetectPlayer;
    [SerializeField] int dronesAmount;
    AudioSource detectionSound;
    List<float> distances = new List<float>();
    float min = 100f;

    void Start()
    {
        spawners = FindObjectsOfType(typeof(DroneSpawner)) as DroneSpawner[];
        canDetectPlayer = true;
        detectionSound = GetComponent<AudioSource>();
    }

    void OnEnable()
    {
        canDetectPlayer = true;
    }

    public void PlayerDetected()
    {
        if (canDetectPlayer)
        {
            canDetectPlayer = false;
            GetClosestSpawner();
            StartCoroutine("DetectionCooldown");
            if (detectionSound != null) detectionSound.Play();
            NotificationHandler.Instance.Detected();
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
            distances.Add(spawners[i].GetDistance());
            if (distances[i] < min)
            {
                min = distances[i];
                index = i;
            }
        }
        spawners[index].StartCoroutine("SpawnDrones", dronesAmount);
    }    
}
