using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;


public class DroneDetection : MonoBehaviour
{
    [SerializeField]DroneSpawner[] spawners; // = FindObjectsOfType(typeof(DroneSpawner)) as DroneSpawner[];
    [SerializeField] float detectionCooldown;
    [SerializeField] bool canDetectPlayer;
    [SerializeField] int dronesAmount;
    AudioSource detectionSound;
    [SerializeField]List<float> distances = new List<float>();
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

    // void Update()
    // {
    //     if(Input.GetKeyDown(KeyCode.X)) Invoke("GetClosestSpawner", 0.2f);
    // }

    IEnumerator DetectionCooldown()
    {
        yield return new WaitForSeconds(detectionCooldown);
        canDetectPlayer = true;
        StopCoroutine("DetectionCooldown");
    }

    void GetClosestSpawner()
    {
        distances.Clear();
        for (int i = 0; i < spawners.Length; i++)
        {
            distances.Add(spawners[i].GetDistance());
        }

        for (int j = 0; j < spawners.Length - 1; j++) {
            for (int i = 0; i < spawners.Length - 1; i++) 
            {
                if (distances[i] > distances[i + 1]) {
                    float temp = distances[i + 1];
                    distances[i + 1] = distances[i];
                    distances[i] = temp;
                    DroneSpawner temp2 = spawners[i + 1];
                    spawners[i + 1] = spawners[i];
                    spawners[i] = temp2;
                }            
            }
        }
        spawners[0].StartCoroutine("SpawnDrones", dronesAmount);
        //Debug.Log($"Closest spawner is {spawners[0].name}");
    }    
}
