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
        if (other.CompareTag("Player")) {
            onTriggerEnter.Invoke();
        }
    }
    
    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player")) {
            onTriggerExit.Invoke();
        }
    }
}
