using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currencyText;

    [SerializeField] private TextMeshProUGUI ItemLifeText;
    [SerializeField] private TextMeshProUGUI ItemStaminaText;
    [SerializeField] private TextMeshProUGUI ItemShotText;

    private InventoryManager inventory;
    ItemManager itemManager;


    void Start()
    {
        inventory = InventoryManager.Instance;
        itemManager = ItemManager.Instance;
    }

    void Update()
    {
        //currencyText.text = inventory.currentCurrency.ToString();

        ItemLifeText.text = itemManager.itemlifeRegen.ToString();
        ItemStaminaText.text = itemManager.itemRunCooldown.ToString();
        ItemShotText.text = itemManager.itemcooldown.ToString();

    }
}
