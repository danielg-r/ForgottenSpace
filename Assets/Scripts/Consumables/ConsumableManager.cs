using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableManager : MonoBehaviour
{
    public GameObject ComLifeRegen;
    public GameObject ComPistolRegen;
    public GameObject ComStaminaRegen;

    ComsuManager consuManager;

    private void Start()
    {
        consuManager = ComsuManager.Instance;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && consuManager.ConsuLifeRegen > 0)
        {//Life
            ComLifeRegen.SetActive(true);
            consuManager.UseLifeRegen();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && consuManager.ConsumableCooldown > 0)
        {//Disparo
            ComPistolRegen.SetActive(true);
            consuManager.UseCooldown();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && consuManager.ConsuStaminaCooldown > 0)
        {//Stamina
            ComStaminaRegen.SetActive(true);
            consuManager.UseRunning();
        }
    }
}
