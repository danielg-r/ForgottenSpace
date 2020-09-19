using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BasicTriggerEvent : MonoBehaviour
{
    public UnityEvent onTriggerEnter;
    public UnityEvent onTriggerExit;


    void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
    }
    
    void OnTriggerExit(Collider other)
    {
        onTriggerExit.Invoke();
    }
}
