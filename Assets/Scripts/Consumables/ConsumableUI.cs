using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ConsumableUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ConsumableLifeText;
    [SerializeField] private TextMeshProUGUI ConsumableStaminaText;
    [SerializeField] private TextMeshProUGUI ConsumableEnergyText;

    ComsuManager ComsuManager;


    void Start()
    {
        
        if (ComsuManager.Instance != null)
        {
            ComsuManager.Instance.OnConsumableUses += new ComsuManager.OnItemAdded(onItemAdded);
        }
        onItemAdded();
    }


    void onItemAdded()
    {
        ConsumableLifeText.text = ComsuManager.Instance.ConsuLifeRegen.ToString();
        ConsumableStaminaText.text = ComsuManager.Instance.ConsuStaminaCooldown.ToString();
        ConsumableEnergyText.text = ComsuManager.Instance.ConsumableCooldown.ToString();
    }



}
