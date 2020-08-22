using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class TimedDoor : MonoBehaviour
{
    [SerializeField] int timer;
    float t = 0;
    public UnityEvent OnTimer;
    bool timerStarted = false;

    void LateUpdate()
    {
        if (timerStarted)
        {
            t += Time.deltaTime;
            if (t > timer)
            {
                OnTimer.Invoke();
            }
        }
    }

    public void StartTimer()
    {
        timerStarted = true;
    }

    public void ResetTime()
    {
        timerStarted = false;
        t = 0;
    }
}
