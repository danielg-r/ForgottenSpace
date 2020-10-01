using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableManager : MonoBehaviour
{
    public GameObject ComLifeRegen;
    public GameObject ComPistolRegen;
    public GameObject ComStaminaRegen;

    ConsuManager consuManager;

    private void Start()
    {
        consuManager = ConsuManager.Instance;
    }

    public void Update()
    {
        if (Input.GetButtonDown("Alpha1") && consuManager.ConsuLifeRegen > 0)
        {//Life
            ComLifeRegen.SetActive(true);
            consuManager.UseLifeRegen();
        }
        if (Input.GetButtonDown("Alpha2") && consuManager.ConsuStaminaCooldown > 0)
        {//Stamina
            ComStaminaRegen.SetActive(true);
            consuManager.UseRunning();
        }
        if (Input.GetButtonDown("Alpha3") && consuManager.ConsumableCooldown > 0)
        {//Disparo
            ComPistolRegen.SetActive(true);
            consuManager.UseCooldown();
        }
    }
}
