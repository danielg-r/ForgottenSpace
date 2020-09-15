using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance { get; private set; }

    public int StaminaValue;
    public int EnergyValue;
    public int LifeValue;

    ConsuManager consuManager;
    InventoryManager inventoryManager;
    CurrencyManager currencymanager;

    void Awake()
    {      
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        consuManager = ConsuManager.Instance;
        inventoryManager = InventoryManager.Instance;
        currencymanager = CurrencyManager.Instance;
    }

    public void BuyStamina()
    {
        if (inventoryManager.currentCurrency >= StaminaValue)
        {
            consuManager.RecolectRunning(1);
            currencymanager.UseCurrency(StaminaValue);
            AudioManager.Instance.Play("Click");
        }
    }

    public void BuyEnergy()
    {
        if (inventoryManager.currentCurrency >= EnergyValue)
        {
            consuManager.RecolectCooldown(1);
            currencymanager.UseCurrency(EnergyValue);
            AudioManager.Instance.Play("Click");
        }
    }

    public void BuyLife()
    {
        if (inventoryManager.currentCurrency >= LifeValue)
        {
            consuManager.RecolectLifeRegen(1);
            currencymanager.UseCurrency(LifeValue);
            AudioManager.Instance.Play("Click");
        }
    }



    //METODOS PARA EL CURSOR
    public void ShowCursor()
    {
        CursorManager.Instance.ShowCursor();
    }
    public void HideCursor()
    {
        CursorManager.Instance.HideCursor();
    }


}
