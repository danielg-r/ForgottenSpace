using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLights : MonoBehaviour
{
    [SerializeField] Light[] lights;
    [SerializeField] Light[] lights2;
    [SerializeField] Color newColor;
    
    void Start()
    {
        lights = GetComponentsInChildren<Light>();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.H)) ChangeLights();
    }

    public void ChangeLights()
    {
        foreach(Light l in lights)
        {
            l.color = newColor;
        }
    }

}
