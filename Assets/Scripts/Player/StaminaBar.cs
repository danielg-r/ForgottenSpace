using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Slider staminaBar;
    [SerializeField] float waitToRegen = 2;
    [SerializeField] int maxStamina = 100;
    [SerializeField] int waitToRegen = 2;
    public int maxStamina = 100;
    public int PlusRegen = 5;
    [SerializeField] int waitToUse = 50;
    public int currentStamina;

    WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    Coroutine regen;
    public UnityEvent CantUse;
    public UnityEvent CanUse;

    bool WasCalled;
    bool canPlay;

    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        WasCalled = false;
        if (gameObject.name == "PistolBar")
        {
            canPlay = true;
        }
        else { canPlay = false; }
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
        if (canPlay)
        {
            AudioManager.Instance.Play("EnergyRecharge");
        }
        if (currentStamina == 0)
        {
            AudioManager.Instance.Play("EnergyRecharge1"); //Cambiar audio
        }
        while (currentStamina < maxStamina)
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
