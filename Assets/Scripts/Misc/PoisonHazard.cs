using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonHazard : Hazard
{
    [SerializeField] GameObject poisonFX;
    [SerializeField] int damagePerTick;
    
    public override void StartHazard() {
        base.StartHazard();
        poisonFX.SetActive(true);
        InvokeRepeating("DamageTick", 5f, eventInterval);
    }

    void DamageTick() {
        PlayerLife.Instance.TakeDamage(damagePerTick);
    }

    public override void HazardFailed() {
        PlayerLife.Instance.Die();
        StopHazard();
    }


    public override void StopHazard() {
        base.StopHazard();
        poisonFX.SetActive(false);
    }
}
