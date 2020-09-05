using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShopUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI StaminaValue;
    [SerializeField] private TextMeshProUGUI EnergyValue;
    [SerializeField] private TextMeshProUGUI LifeValue;

    [SerializeField] private TextMeshProUGUI Money;

    ShopManager ShopManager;

    void Start()
    {
        StaminaValue.text = InventoryManager.Instance.currentCurrency.ToString();

        StaminaValue.text = ShopManager.Instance.StaminaValue.ToString();
        EnergyValue.text = ShopManager.Instance.EnergyValue.ToString();
        LifeValue.text = ShopManager.Instance.LifeValue.ToString();
    }

    

}
