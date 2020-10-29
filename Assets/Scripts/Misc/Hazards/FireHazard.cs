using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireHazard : Hazard
{
    [SerializeField] GameObject fireFX;
    [SerializeField] int damagePerTick;

    public override void StartHazard() {
        base.StartHazard();
        fireFX.SetActive(true);
    }   

    public override void HazardFailed() {
        //PlayerLife.Instance.Die();
        StopHazard();
    }

    public void DamageTick() {
        PlayerLife.Instance.TakeDamage(damagePerTick);
    }

    public override void StopHazard() {
        base.StopHazard();
        fireFX.SetActive(false);
    }

}
