using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HazardManager : MonoBehaviour
{
    static HazardManager instance;
    public static HazardManager Instance { get => instance; }
    [SerializeField] List<RotateManager> puzzles;
    [SerializeField] Hazard[] hazards;
    [SerializeField] float hazardInterval;
    bool activeHazard;
    float t = 0;

    void Awake() {
        if(instance == null) instance = this;
    }

    void Start() {
        foreach (RotateManager rt in FindObjectsOfType<RotateManager>())
        {
            puzzles.Add(rt);
        }
    }

    void Update() {
        t += Time.deltaTime;
        if (!activeHazard && t > hazardInterval) {
            int rnd = Random.Range(0, hazards.Length);
            hazards[rnd].StartHazard();
            activeHazard = true;
        }
    }



    public void StopHazards() {
        foreach (Hazard h in hazards) {
            h.StopHazard();
        }
        t = 0;
        activeHazard = false;
    }

}
