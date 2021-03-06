﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [Header("Inventario")]
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private TextMeshProUGUI circsText;
    [SerializeField] private TextMeshProUGUI platesText;

    private InventoryManager inventory;
    ConsuManager itemManager;

    [Header("Pistola")]
    [SerializeField] private TextMeshProUGUI CircuitsPistol;
    [SerializeField] private TextMeshProUGUI PlatesPistol;

    [Header("Ship")]
    [SerializeField] private TextMeshProUGUI CurrentShipPieces;


    [Header("Shop")]
    [SerializeField] private TextMeshProUGUI StaminaValue;
    [SerializeField] private TextMeshProUGUI EnergyValue;
    [SerializeField] private TextMeshProUGUI LifeValue;
    [SerializeField] private TextMeshProUGUI Currency;




    void Start()
    {
        if (CurrencyManager.Instance != null)
        {
            CurrencyManager.Instance.onCurrAdded += new CurrencyManager.OnCurrencyAdded(OnCurrAdded);
        }
        if (CraftSystem.Instance != null)
        {
            CraftSystem.Instance.onCurrSpent += new CraftSystem.OnCurrencySpent(OnCurrSpent);
        }
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.onPiecesAdded += new InventoryManager.OnCurrencyAdded(OnPiecesAdd);
        }

        inventory = InventoryManager.Instance;
        itemManager = ConsuManager.Instance;

        StaminaValue.text = "<color=green>" + ShopManager.Instance.StaminaValue.ToString() + " $ </color>";
        EnergyValue.text = "<color=green>" + ShopManager.Instance.EnergyValue.ToString() + " $ </color>";
        LifeValue.text = "<color=green>" + ShopManager.Instance.LifeValue.ToString() + " $ </color>";

    }

    void OnCurrAdded()
    {

        currencyText.text = inventory.currentCurrency.ToString();
        circsText.text = inventory.currentCircuits.ToString();
        platesText.text = inventory.currentPlates.ToString();

        CircuitsPistol.text = inventory.currentCircuits.ToString();
        PlatesPistol.text = inventory.currentPlates.ToString();

        Currency.text = "$ " + InventoryManager.Instance.currentCurrency.ToString();
    }

    void OnCurrSpent()
    {
        currencyText.text = inventory.currentCurrency.ToString();
        circsText.text = inventory.currentCircuits.ToString();
        platesText.text = inventory.currentPlates.ToString();

        CircuitsPistol.text = inventory.currentCircuits.ToString();
        PlatesPistol.text = inventory.currentPlates.ToString();

        CurrentShipPieces.text = inventory.shipPieceCount.ToString();

        Currency.text = "$ " + InventoryManager.Instance.currentCurrency.ToString();
    }

    void OnPiecesAdd()
    {
        CurrentShipPieces.text = inventory.shipPieceCount.ToString();
        ObjectiveManager.Instance.SetCurrentObjective($"Recupera las piezas de tu nave para evacuar la estación. ({inventory.shipPieceCount}/5)");

    }

}
