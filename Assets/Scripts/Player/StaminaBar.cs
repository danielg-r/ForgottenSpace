using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Slider staminaBar;
    [SerializeField] int waitToRegen = 2;
    [SerializeField] int maxStamina = 100;
    public int PlusRegen = 5;
    [SerializeField] int waitToUse = 50;
    int currentStamina;

    WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    Coroutine regen;
    public UnityEvent CantUse;
    public UnityEvent CanUse;

    bool WasCalled;

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        WasCalled = false;
    }

    public bool UseStamina(int amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;

            if (regen != null)
                StopCoroutine(regen);
            regen = StartCoroutine(regenStamina());

            return true;
        }
        else
        {
            CantUse.Invoke();
            WasCalled = false;
            return false;
        }
    }

    IEnumerator regenStamina()
    {
        yield return new WaitForSeconds(waitToRegen);

        while(currentStamina < maxStamina)
        {
            currentStamina += PlusRegen;
            staminaBar.value = currentStamina;
            yield return regenTick;
            if (currentStamina > waitToUse && !WasCalled)
            {
                CanUse.Invoke();
                WasCalled = true;
            }
        }
        regen = null;
    }
}
