using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class BasicTriggerEvent : MonoBehaviour
{
    public UnityEvent onTriggerEnter;

    void OnTriggerEnter(Collider other)
    {
        onTriggerEnter.Invoke();
    }
}
