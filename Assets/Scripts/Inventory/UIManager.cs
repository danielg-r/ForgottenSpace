using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;
    [SerializeField] private TextMeshProUGUI gunPieceText;
    [SerializeField] private TextMeshProUGUI suitPieceText;

    private InventoryManager inventory;
    

    void Start()
    {
        if (CurrencyManager.Instance != null)
        {
            CurrencyManager.Instance.onCurrAdded += new CurrencyManager.OnCurrencyAdded(OnCurrAdded);
        }
        inventory = InventoryManager.Instance;
    }

    void OnCurrAdded()
    {
        currencyText.text = inventory.currentCurrency.ToString();
        gunPieceText.text = inventory.currentGunPieces.ToString();
        suitPieceText.text = inventory.currentSuitPieces.ToString();
    }
}
