using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DroneAttackDetection : MonoBehaviour, IDamageable
{
    [System.Serializable]
    public class OnDamageTaken : UnityEvent<int> { };
    public OnDamageTaken onDamageTaken;

    public void TakeDamage(int amount)
    {
        onDamageTaken.Invoke(amount);
    }
}
