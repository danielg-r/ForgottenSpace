using System.Collections;
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

    public void LootFound()
    {
        lootFound.OpenNotification();
    }

    public void Detected()
    {
        detected.OpenNotification();
    }

    public void DoorLocked()
    {
        doorLocked.OpenNotification();
    }

    // Función de ejemplo con posibilidad de modificar la notificación en caso de que sea necesario.
    // public void PuzzleHint(string title, string desc)
    // {
    //     puzzleHint.title = title;
    //     puzzleHint.description = desc;
    //     puzzleHint.OpenNotification();
    // }
}
