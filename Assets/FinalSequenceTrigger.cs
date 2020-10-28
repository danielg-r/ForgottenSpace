using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FinalSequenceTrigger : MonoBehaviour
{
    InventoryManager inventory;
    public UnityEvent onAlphaCompleted;

    void Start()
    {
        inventory = InventoryManager.Instance;
    }

    void Update()
    {
        if (inventory.shipPieceCount == 5)
        {
            onAlphaCompleted.Invoke();
            this.enabled = false;
        }            
    }
}
