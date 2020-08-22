using SciFiArsenal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    public int pieces = 0; //Esto serian piezas del inventario
    public int necessaryPieces = 3; //Valor interno
    public bool CanCraft = false;
    private bool ItCrafted = false;

    [SerializeField] InteraCraft interaCraft;

    
    public void Update()
    {
        if ( pieces >= necessaryPieces)
        {
            CanCraft = true;
        }
        else
        {
            CanCraft = false;
            
        }

        if (ItCrafted == false)
        {
            ActivatePistol.Instance.Deactivate();
        }

    }

    public void Craft()
    {
        if (CanCraft)
        {
            if (pieces >= necessaryPieces)
            {
                ActivatePistol.Instance.Activate();
                pieces -= necessaryPieces;                
                CanCraft = false;
                ItCrafted = true;
            }
        }
    }

    

}
