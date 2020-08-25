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

    ConsuManager ConsuManager;


    void Start()
    {
        
        if (ConsuManager.Instance != null)
        {
            ConsuManager.Instance.OnConsumableUses += new ConsuManager.OnItemAdded(onItemAdded);
        }
        onItemAdded();
    }


    void onItemAdded()
    {
        ConsumableLifeText.text = ConsuManager.Instance.ConsuLifeRegen.ToString();
        ConsumableStaminaText.text = ConsuManager.Instance.ConsuStaminaCooldown.ToString();
        ConsumableEnergyText.text = ConsuManager.Instance.ConsumableCooldown.ToString();
    }



}
