using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class HazardManager : MonoBehaviour
{
    static HazardManager instance;
    public static HazardManager Instance { get => instance; }
    [SerializeField] List<RotateManager> puzzles;
    [SerializeField] Hazard[] hazards;
    [SerializeField] float hazardInterval;
    [SerializeField] PlayableDirector pb;
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
        Invoke("InstantHazard", 30f);
    }

    void Update() {
        t += Time.deltaTime;
        StartRandomHazard();        
    }

    void DisablePuzzles() {
        foreach (RotateManager rt in puzzles) {
            PlayerCameraController.Instance.canvasText.text = "";
            rt.interactable.GetComponent<BoxCollider>().enabled = false;
            rt.interactable.enabled = false;
            rt.ps.SetActive(false);
            rt.ps2.SetActive(false);
        }
    }

    void EnablePuzzles() {
        foreach (RotateManager rt in puzzles) {
            rt.interactable.GetComponent<BoxCollider>().enabled = true;
            rt.interactable.enabled = true;
            rt.ps.SetActive(true);
            rt.ps2.SetActive(true);
        }
    }

    public void StartRandomHazard() {
        if (!activeHazard && t > hazardInterval) {
            Debug.Log("Starting  random hazard");
            int rnd = Random.Range(0, hazards.Length);
            hazards[rnd].StartHazard();
            activeHazard = true;
            EnablePuzzles();
        }
    }

    public void InstantHazard() {
        Debug.Log("Starting instant hazard");
        int rnd = Random.Range(0, hazards.Length);
        hazards[rnd].StartHazard();
        activeHazard = true;
        EnablePuzzles();
    }

    public void StopHazards() {
        foreach (Hazard h in hazards) {
            h.StopHazard();
        }
        t = 0;
        activeHazard = false;
        DisablePuzzles();
    }

}
