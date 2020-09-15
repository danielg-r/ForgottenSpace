using System.Collections;
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
    //[SerializeField] private TextMeshProUGUI CircuitsShip;
    [SerializeField] private TextMeshProUGUI CurrentShipPieces;


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
        if (InventoryManager.Instance != null)
        {
            InventoryManager.Instance.onPiecesAdded += new InventoryManager.OnCurrencyAdded(OnPiecesAdd);
        }

        inventory = InventoryManager.Instance;
        itemManager = ConsuManager.Instance;

    }
    void OnCurrAdded()
    {
        CircuitsPistol.text = inventory.currentCircuits.ToString();
        PlatesPistol.text = inventory.currentPlates.ToString();

        CircuitsArmor.text = inventory.currentCircuits.ToString();
        PlatesArmor.text = inventory.currentPlates.ToString();        
    }



    void OnCurrSpent()
    {      
        CircuitsPistol.text = inventory.currentCircuits.ToString();
        PlatesPistol.text = inventory.currentPlates.ToString();

        CircuitsArmor.text = inventory.currentCircuits.ToString();
        PlatesArmor.text = inventory.currentPlates.ToString();
    }

    void OnPiecesAdd()
    {
        CurrentShipPieces.text = inventory.shipPieceCount.ToString();

    }



}
