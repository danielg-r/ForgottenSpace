using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{
    public delegate void OnCurrencyAdded();
    public event OnCurrencyAdded onCurrAdded;
    public static CurrencyManager Instance { get; private set; }


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

    public void AddCurrency(int currAmount)
    {
        InventoryManager.Instance.currentCurrency += currAmount;
        onCurrAdded();
        //Sonido (?) SITUVIERAUNO
    }

    public void UseCurrency(int _currAmount)
    {
        InventoryManager.Instance.currentCurrency -= _currAmount;
        onCurrAdded();
    }

    public void AddCircuits(int circAmount)
    {
        InventoryManager.Instance.currentCircuits += circAmount;
        onCurrAdded();
        //Sonido (?) SITUVIERAUNO
    }

    public void AddPlates(int plateAmount)
    {
        InventoryManager.Instance.currentPlates += plateAmount;
        onCurrAdded();
        //Sonido (?) SITUVIERAUNO
    }

}
