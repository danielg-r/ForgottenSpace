using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Currency Manager", menuName = "ForgottenSpace/CurrencyManager")]
public class CurrencyManager : ScriptableObject
{
    public void AddCurrency(int amount)
    {
        InventoryManager.Instance.currentCurrency += amount;
        //Sonido (?)
    }
}
