using System.Collections;
using System.Collections.Generic;
using UnityEditor;
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
    [SerializeField] GameObject charger;
    Material chargerMaterial;
    Color colour;

    private void OnEnable()
    {
        if (regen != null)
            StopCoroutine(regen);
        regen = StartCoroutine(regenStamina());
    }

    void Start()
    {
        PlayerLife.Instance.onPlayerRespawned += Refill;
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        WasCalled = false;
        if (gameObject.name == "PistolBar")
        {
            canPlay = true;
        }
        else { canPlay = false; }
        if (canPlay)
        {
            chargerMaterial = charger.GetComponent<Renderer>().material;
            colour = chargerMaterial.GetColor("_EmissionColor");
        }
    }

    void Refill() {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
    }

    public bool UseStamina(float amount)
    {
        if(currentStamina - amount >= 0 && !PlayerLife.Instance.isDead)
        {
            currentStamina -= amount;
            staminaBar.value = currentStamina;
            if (canPlay) 
            {
                Light.range = (currentStamina * RangeInitial) / maxStamina;
                colour = Vector4.one*(currentStamina / maxStamina);
                chargerMaterial.SetColor("_EmissionColor", colour);
            }
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
                AudioManager.Instance.Play("EnergyRecharge");
            }
            else AudioManager.Instance.Play("EnergyRecharge1");
        }
        
        while (currentStamina < maxStamina)
        {
            if (canPlay)
            {
                Light.range = (currentStamina * RangeInitial) / maxStamina;
                colour = Vector4.one*(currentStamina / maxStamina);
                chargerMaterial.SetColor("_EmissionColor", colour);
            }
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
