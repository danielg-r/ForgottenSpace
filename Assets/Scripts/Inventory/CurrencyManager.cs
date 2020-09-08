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

    public void AddGunPiece(int gPieceAmount)
    {
        InventoryManager.Instance.currentGunPieces += gPieceAmount;
        onCurrAdded();
        //Sonido (?) SITUVIERAUNO
    }

    public void AddSuitPiece(int sPieceAmount)
    {
        InventoryManager.Instance.currentSuitPieces += sPieceAmount;
        onCurrAdded();
        //Sonido (?) SITUVIERAUNO
    }

}
