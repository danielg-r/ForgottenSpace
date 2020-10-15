using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumableManager : MonoBehaviour
{
    public GameObject ComLifeRegen;
    public GameObject ComPistolRegen;
    public GameObject ComStaminaRegen;

    ConsuManager consuManager;

    bool isAxisInUse_1;
    bool isAxisInUse_2;

    private void Start()
    {
        consuManager = ConsuManager.Instance;
    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1) && consuManager.ConsuLifeRegen > 0)
        {//Life
            ComLifeRegen.SetActive(true);
            consuManager.UseLifeRegen();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && consuManager.ConsuStaminaCooldown > 0)
        {//Stamina
            ComStaminaRegen.SetActive(true);
            consuManager.UseRunning();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && consuManager.ConsumableCooldown > 0)
        {//Disparo
            ComPistolRegen.SetActive(true);
            consuManager.UseCooldown();
        }

        if (Input.GetAxisRaw("Alpha1") == 0)
        {
            isAxisInUse_1 = false;
        }
        if (Input.GetAxisRaw("Alpha1") < 0)
        {
            if (!isAxisInUse_1 && consuManager.ConsuLifeRegen > 0)
            {
                ComLifeRegen.SetActive(true);
                consuManager.UseLifeRegen();
                isAxisInUse_1 = true;
            }
        }

        if (Input.GetAxisRaw("Alpha2") == 0)
        {
            isAxisInUse_2 = false;
        }
        if (Input.GetAxisRaw("Alpha2") > 0)
        {
            if (!isAxisInUse_2 && consuManager.ConsuStaminaCooldown > 0)
            {
                ComStaminaRegen.SetActive(true);
                consuManager.UseRunning();
                isAxisInUse_2 = true;
            }
        }
        if (Input.GetAxisRaw("Alpha2") < 0)
        {
            if (!isAxisInUse_2 && consuManager.ConsumableCooldown > 0)
            {
                ComPistolRegen.SetActive(true);
                consuManager.UseCooldown();
                isAxisInUse_2 = true;
            }
        }
    }
}
