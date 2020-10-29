using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Events;

public class FinalSequenceTrigger : MonoBehaviour
{
    InventoryManager inventory;
    [SerializeField] GameObject shipLights;
    public UnityEvent onAlphaCompleted;
    [SerializeField] PlayableDirector HangarCinematic; 
    [SerializeField] PlayableDirector FinalCinematic;

    void Start()
    {
        inventory = InventoryManager.Instance;
        CraftSystem.Instance.onShipCrafted += ShipCrafted;
    }

    void Update()
    {
        if (inventory.shipPieceCount == 5)
        {
            onAlphaCompleted.Invoke();
            this.enabled = false;
        }            
    }

    void ShipCrafted() {
        ObjectiveManager.Instance.SetCurrentObjective("Instala el nuevo motor en tu nave", true);
        shipLights.SetActive(true);
        HangarCinematic.Play();
        HazardManager.Instance.StopHazards();
        HazardManager.Instance.enabled = false;
    }
}
