using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;

    private InventoryManager inventory;

    void Start()
    {
        inventory = InventoryManager.Instance;
    }

    void Update()
    {
        currencyText.text = inventory.currentCurrency.ToString();
    }
}
