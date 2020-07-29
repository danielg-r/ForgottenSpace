using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class DoorTimer : MonoBehaviour
{
    float t = 0;
    public UnityEvent OnTimer;
    [SerializeField]int timer; 

    void Update()
    {
        t += Time.deltaTime;
        if (t > timer)
        {
            Debug.Log("Timer terminado");
            OnTimer.Invoke();
        } 
    }
}
