﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class NotificationTest : MonoBehaviour
{
    public UnityEvent TestNotifications;
    void Start()
    {
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) TestNotifications.Invoke();
    }
}