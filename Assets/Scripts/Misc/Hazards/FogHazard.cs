using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FogHazard : Hazard
{
    public override void StartHazard() {
        base.StartHazard();
        RenderSettings.fogDensity = 0.5f;
    }

    public override void StopHazard() {
        base.StopHazard();
        RenderSettings.fogDensity = 0.15f;
    }
}
