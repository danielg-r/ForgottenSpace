using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComsumableManager : MonoBehaviour
{
    public GameObject ComLifeRegen;
    public GameObject ComPistolRegen;
    public GameObject ComStaminaRegen;

    ItemManager itemManager;

    private void Start()
    {
        itemManager = ItemManager.Instance;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && itemManager.itemlifeRegen > 0)
        {//Life
            ComLifeRegen.SetActive(true);
            itemManager.UseLifeRegen();
        }
        if (Input.GetKeyDown(KeyCode.T) && itemManager.itemcooldown > 0)
        {//Disparo
            ComPistolRegen.SetActive(true);
            itemManager.UseCooldown();
        }
        if (Input.GetKeyDown(KeyCode.Y) && itemManager.itemRunCooldown > 0)
        {//Stamina
            ComStaminaRegen.SetActive(true);
            itemManager.UseRunning();
        }
    }
}
