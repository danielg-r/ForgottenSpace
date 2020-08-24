using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;


public class ItemUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI ItemLifeText;
    [SerializeField] private TextMeshProUGUI ItemStaminaText;
    [SerializeField] private TextMeshProUGUI ItemShotText;

    ComsuManager ComsuManager;


    void Start()
    {
        
        if (ComsuManager.Instance != null)
        {
            ComsuManager.Instance.onItemAdded += new ComsuManager.OnItemAdded(onItemAdded);
        }
        onItemAdded();
    }


    void onItemAdded()
    {
        ItemLifeText.text = ComsuManager.Instance.itemlifeRegen.ToString();
        ItemStaminaText.text = ComsuManager.Instance.itemRunCooldown.ToString();
        ItemShotText.text = ComsuManager.Instance.itemcooldown.ToString();
    }



}
