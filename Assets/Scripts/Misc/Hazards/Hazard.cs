using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Hazard : MonoBehaviour
{
    //Peligro simple que va a hacerle daño al jugador cada x segundos hasta que vuelva a activar la energía.(llamar método de MusicManager).
    [SerializeField] Timer hazardTimer;
    [SerializeField] string hazardName;
    [TextArea]
    [SerializeField] string hazardDesc;
    bool isActive;
    [SerializeField] float hazardTime;

    void Start() {
        PlayerLife.Instance.onPlayerDied += StopHazard;
    }

    public virtual void HazardFailed() {        
    }

    public virtual void StartHazard() {
        //MusicManager.Instance.PlaySong();
        hazardTimer.StartTimer(hazardTime);
        NotificationHandler.Instance.HazardNotification(hazardName, hazardDesc);
        isActive = true;
    }

    public virtual void StopHazard() {
        if (isActive) {
            NotificationHandler.Instance.HazardCompleted();
            //MusicManager.Instance.StopSong();
            isActive = false;
            CancelInvoke();
            hazardTimer.StopTimer();
        }
    }
}
