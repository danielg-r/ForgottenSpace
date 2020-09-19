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

    void Start()
    {

        if (CurrencyManager.Instance != null)
        {
            CurrencyManager.Instance.onCurrAdded += new CurrencyManager.OnCurrencyAdded(onCurrAdded);
        }
        //Money.text = InventoryManager.Instance.currentCurrency.ToString();

        StaminaValue.text = "< color = green > + " + ShopManager.Instance.StaminaValue.ToString() + " $ </ color >"  ;
        EnergyValue.text = "< color = green > + " + ShopManager.Instance.EnergyValue.ToString() + " $ </ color >" ;
        LifeValue.text = "< color = green > + " + ShopManager.Instance.LifeValue.ToString() + " $ </ color >" ;
    }

    void onCurrAdded()
    {
        Money.text = "$ " + InventoryManager.Instance.currentCurrency.ToString();
    }



}
