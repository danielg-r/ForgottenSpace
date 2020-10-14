using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hazard : MonoBehaviour
{
    //Peligro simple que va a hacerle daño al jugador cada x segundos hasta que vuelva a activar la energía.
    [SerializeField] Timer hazardTimer;
    [SerializeField] string hazardName;
    [TextArea]
    [SerializeField] string hazardDesc;
    bool isActive;
    [SerializeField] float eventInterval;
    [SerializeField] float hazardTime;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) {
            StartHazard();
        }
        if (Input.GetKeyDown(KeyCode.J)) {
            Time.timeScale = 3f;
        }
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
