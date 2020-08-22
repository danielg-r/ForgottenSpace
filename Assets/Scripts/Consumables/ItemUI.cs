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

    ItemManager itemManager;


    void Start()
    {
        
        if (ItemManager.Instance != null)
        {
            ItemManager.Instance.onItemAdded += new ItemManager.OnItemAdded(onItemAdded);
        }
        onItemAdded();
    }


    void onItemAdded()
    {
        ItemLifeText.text = ItemManager.Instance.itemlifeRegen.ToString();
        ItemStaminaText.text = ItemManager.Instance.itemRunCooldown.ToString();
        ItemShotText.text = ItemManager.Instance.itemcooldown.ToString();
    }



}
