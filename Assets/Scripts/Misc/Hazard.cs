using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public abstract class Hazard : MonoBehaviour
{
    //Peligro simple que va a hacerle daño al jugador cada x segundos hasta que vuelva a activar la energía.
    [SerializeField] Timer hazardTimer;
    [SerializeField] string hazardName;
    [TextArea]
    [SerializeField] string hazardDesc;
    bool isActive;
    public float eventInterval;
    [SerializeField] float hazardTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            StartHazard();
        }
    }

    public virtual void HazardFailed() {        
    }

    public virtual void StartHazard() {
        //TO-DO: Agregar cualquier sonido o forma de feedback.
        hazardTimer.StartTimer(hazardTime);
        NotificationHandler.Instance.HazardNotification(hazardName, hazardDesc);
        isActive = true;
    }

    public virtual void StopHazard() {
        if (isActive) {
            NotificationHandler.Instance.HazardCompleted();
            isActive = false;
            CancelInvoke();
            hazardTimer.StopTimer();
        }
    }
}
