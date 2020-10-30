using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

public class LoreInspect : MonoBehaviour
{
    //Pasarle un modal window al item y guardarlos en un array de las mismas en el InventoryManager, mandarle un id al método de este script
    //
    //Y colocarselo al botón del slot en el inventario, y ahí pasarle el ID correspondiente a la posición del array
    //
    //jeje
    private Slot slot;

    public void InspectEntry (int id)
    {
        for (int i = 0; i < InventoryManager.Instance.loreSlots.Length; i++)
        {
            if (InventoryManager.Instance.loreSlots[id].GetComponent<Slot>().isEmpty == false)
            {
                InventoryManager.Instance.windowArray[id].OpenWindow();
                CursorManager.Instance.ShowCursor();
                Inventory.Instance.canClose = false;
            }        
        }      
    }
}
