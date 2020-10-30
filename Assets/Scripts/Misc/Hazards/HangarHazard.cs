using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;


public class HangarHazard : MonoBehaviour
{
    //Peligro simple que va a hacerle daño al jugador cada x segundos hasta que vuelva a activar la energía.
    [SerializeField] Timer hazardTimer;
    [SerializeField] string hazardName;
    [TextArea]
    [SerializeField] string hazardDesc;
    [SerializeField] float hazardTime;
    [SerializeField] GameObject spawners; 
    [SerializeField] HangarSpawner[] hSpawners;
    [SerializeField] PlayableDirector FinalCinematic; 
    bool isActive;

    void Start() {
        PlayerLife.Instance.onPlayerRespawned += RestartHazard;
        PlayerLife.Instance.onPlayerDied += StopHazard;
        hSpawners = spawners.GetComponentsInChildren<HangarSpawner>();
    }

    public void StartHazard() {
        spawners.SetActive(true);
        MusicManager.Instance.PlaySong();
        hazardTimer.StartTimer(hazardTime);
        NotificationHandler.Instance.HazardNotification(hazardName, hazardDesc);
        isActive = true;       
        ObjectiveManager.Instance.SetCurrentObjective("Sobrevive mientras carga la energía del motor.", true);
    }

    public void StopHazard() {
        spawners.SetActive(false);
        MusicManager.Instance.StopSong();
        NotificationHandler.Instance.HazardCompleted();
        isActive = false;
        hazardTimer.StopTimer();
    }

    public void EndHazard() {
        StopHazard();
        FinalCinematic.Play();
        PlayerLife.Instance.gameObject.SetActive(false);
    }

    void RestartHazard() {
        foreach (HangarSpawner hsp in hSpawners) {
            hsp.ClearEnemies();
        }
        StopHazard();
        Invoke("StartHazard", 0.2f);
    }
}
