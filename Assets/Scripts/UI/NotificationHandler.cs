﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

using Michsky.UI.ModernUIPack;

public class NotificationHandler : MonoBehaviour
{
    public static NotificationHandler Instance {get; private set;}

    [SerializeField] NotificationManager puzzleHint;
    [SerializeField] NotificationManager puzzleComplete;
    [SerializeField] NotificationManager generatorHint;
    [SerializeField] NotificationManager lootFound;
    [SerializeField] NotificationManager detected;
    [SerializeField] NotificationManager doorLocked;
    [SerializeField] NotificationManager inspect;
    [SerializeField] NotificationManager currencyAdded;
    [SerializeField] NotificationManager hazardNotification;


    void Awake()
    {
        if (Instance == null) Instance = this;
    }

    public void PuzzleHint()
    {
        puzzleHint.OpenNotification();
    }

    public void PuzzleComplete()
    {
        puzzleComplete.OpenNotification();
    }

    public void GeneratorHint()
    {
        generatorHint.OpenNotification();
    }

    // public void LootFound()
    // {        
    //     hazardNotification.UpdateUI();
    //     lootFound.OpenNotification();
    // }

    public void Detected()
    {
        detected.OpenNotification();
    }

    public void DoorLocked()
    {
        doorLocked.OpenNotification();
    }
    public void LootFound(string desc)
    {
        lootFound.description = desc.ToString();
        lootFound.UpdateUI();
        lootFound.OpenNotification();
    }
    public void Inspect()
    {
        inspect.OpenNotification();
    }

    public void CurrencyAdded(string desc)
    {
        currencyAdded.description = desc.ToString();
        currencyAdded.UpdateUI();
        currencyAdded.OpenNotification();
    }

    public void HazardNotification(string title, string desc)
    {
        hazardNotification.title = title.ToString();
        hazardNotification.description = desc.ToString();
        hazardNotification.UpdateUI();
        hazardNotification.OpenNotification();
    }

    public void HazardCompleted() {
        hazardNotification.CloseNotification();
    }
}
