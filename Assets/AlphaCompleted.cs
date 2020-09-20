using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AlphaCompleted : MonoBehaviour
{
    InventoryManager inventory;
    public UnityEvent onAlphaCompleted;

    void Start()
    {
        inventory = InventoryManager.Instance;
    }

    void Update()
    {
        if (inventory.shipPieceCount > 3)
        {
            onAlphaCompleted.Invoke();
            this.enabled = false;
        }            
    }
}
