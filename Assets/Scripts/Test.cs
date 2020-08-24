using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Test : MonoBehaviour
{
    public UnityEvent onTest;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            onTest.Invoke();
        }
    }


}
