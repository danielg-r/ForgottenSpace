﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftingUI : MonoBehaviour
{
    [Header("Pistola")]
    [SerializeField] private TextMeshProUGUI CircuitsPistol;
    [SerializeField] private TextMeshProUGUI PlatesPistol;

    [Header("Armor")]
    [SerializeField] private TextMeshProUGUI CircuitsArmor;
    [SerializeField] private TextMeshProUGUI PlatesArmor;

    [Header("Ship")]
    [SerializeField] private TextMeshProUGUI CircuitsShip;
    [SerializeField] private TextMeshProUGUI PlatesShip;

    private InventoryManager inventory;
    ConsuManager itemManager;

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
        inventory = InventoryManager.Instance;
        itemManager = ConsuManager.Instance;
    }
    void OnCurrAdded()
    {
        CircuitsPistol.text = inventory.currentGunPieces.ToString();
        PlatesPistol.text = inventory.currentSuitPieces.ToString();

        CircuitsArmor.text = inventory.currentGunPieces.ToString();
        PlatesArmor.text = inventory.currentSuitPieces.ToString();

        //CircuitsShip.text = inventory.currentGunPieces.ToString();
        //PlatesShip.text = inventory.currentSuitPieces.ToString();
    }

    void OnCurrSpent()
    {      
        CircuitsPistol.text = inventory.currentGunPieces.ToString();
        PlatesPistol.text = inventory.currentSuitPieces.ToString();

        CircuitsArmor.text = inventory.currentGunPieces.ToString();
        PlatesArmor.text = inventory.currentSuitPieces.ToString();

        CircuitsShip.text = inventory.currentGunPieces.ToString();
        PlatesShip.text = inventory.currentSuitPieces.ToString();
    }


}
