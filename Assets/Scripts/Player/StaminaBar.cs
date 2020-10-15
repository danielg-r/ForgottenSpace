using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Experimental.GlobalIllumination;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    [SerializeField] Slider staminaBar;
    public float waitToRegen = 2;
    public float maxStamina = 100;
    public float PlusRegen = 5;
    [SerializeField] float waitToUse = 50;

    [HideInInspector] public float currentStamina;

    WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    Coroutine regen;
    public UnityEvent CantUse;
    public UnityEvent CanUse;

    bool WasCalled;
    bool canPlay;

    float RangeInitial = 0.35f;
    [SerializeField] Light Light;

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

    public bool UseStamina(float amount)
    {
        if(currentStamina - amount >= 0)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;
            if (canPlay) Light.range = (currentStamina * RangeInitial) / maxStamina;
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
            if (currentStamina == 0)
            {
                AudioManager.Instance.Play("EnergyRecharge"); //Cambiar audio
            }
            else AudioManager.Instance.Play("EnergyRecharge");
        }
        
        while (currentStamina < maxStamina)
        {
            //Light.range = (currentStamina * RangeInitial) / maxStamina;
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
