﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaminaColdown : MonoBehaviour
{
    [SerializeField] StaminaBar SBar;
    float AmountRegenOriginal;
    [SerializeField] float AmountRegenPlus;

    float Duration = 15f;


    void OnEnable() //Se llama esta función cuando el gameobject se pone activo.
    {
        
        AmountRegenOriginal = SBar.PlusRegen;
        SBar.PlusRegen = AmountRegenPlus + SBar.PlusRegen;

        StartCoroutine(ActiveTimeRegen());
    }

    void Disable()
    {
        SBar.PlusRegen = AmountRegenOriginal;
        this.gameObject.SetActive(false);
    }

    IEnumerator ActiveTimeRegen()
    {
        yield return new WaitForSeconds(Duration);
        Disable();
    }

}


