using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TutorialHazard : MonoBehaviour
{
    //Peligro simple que va a hacerle daño al jugador cada x segundos hasta que vuelva a activar la energía.
    [SerializeField] Timer hazardTimer;
    [SerializeField] string hazardName;
    [TextArea]
    [SerializeField] string hazardDesc;
    [SerializeField] int damage;
    bool isActive;
    [SerializeField] float eventInterval;
    [SerializeField] float hazardTime;

    public void StartHazard() {
        //TO-DO: Agregar cualquier sonido o forma de feedback.
        hazardTimer.StartTimer(hazardTime);
        NotificationHandler.Instance.HazardNotification(hazardName, hazardDesc);
        isActive = true;       
        InvokeRepeating("HazardTick", 5f, eventInterval);
        ObjectiveManager.Instance.SetCurrentObjective("Busca el generador para activar la energía.");
    }

    public void HazardTick() {
        Debug.Log("HazardTick");
        PlayerLife.Instance.TakeDamage(damage);
    }

    public void StopHazard() {
        NotificationHandler.Instance.HazardCompleted();
        isActive = false;
        CancelInvoke();
        hazardTimer.StopTimer();
        ObjectiveManager.Instance.SetCurrentObjective("Busca la estación de reparación para construir un arma.");
    }
}
