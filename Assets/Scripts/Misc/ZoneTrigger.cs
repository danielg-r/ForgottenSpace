using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTrigger : MonoBehaviour
{
    [SerializeField] string zoneText;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (!UIDeathControl.Instance.showingText) UIDeathControl.Instance.SetStatusText(zoneText);
        }
    }
}
