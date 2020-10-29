﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsuManager : MonoBehaviour
{
    public delegate void OnItemAdded();
    public event OnItemAdded OnConsumableUses;

    public static ConsuManager Instance { get; private set; }

    public int ConsumableCooldown; //{ get; private set; }
    public int ConsuLifeRegen; //{ get; private set; }
    public int ConsuStaminaCooldown; // { get; private set; }

    public GameObject ComLifeRegen;
    public GameObject ComPistolRegen;
    public GameObject ComStaminaRegen;

    bool isAxisInUse_1;
    bool isAxisInUse_2;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
    private void Start()
    {        
        LimitMaxValues();
    }

    #region Use & Recolect
    //--------------------
    public void UseCooldown()
    {                
        ConsumableCooldown--;
        OnConsumableUses();
    }
    public void RecolectCooldown(int _coldown)
    {
        ConsumableCooldown += _coldown;
        OnConsumableUses();
    }
    //---------------------
    public void UseLifeRegen()
    {
        ConsuLifeRegen--;
        OnConsumableUses();
    }
    public void RecolectLifeRegen(int _liferegen)
    {
        ConsuLifeRegen += _liferegen;
        OnConsumableUses();
    }
    //----------------------
    public void UseRunning()
    {
        ConsuStaminaCooldown--;
        OnConsumableUses();
    }
    public void RecolectRunning(int _runCooldown)
    {
        ConsuStaminaCooldown += _runCooldown;
        OnConsumableUses();
    }
    #endregion



    public void Update()
    {
        LimitMaxValues();


        if (Input.GetKeyDown(KeyCode.Alpha1) && ConsuLifeRegen > 0)
        {//Life
            ComLifeRegen.SetActive(true);
            UseLifeRegen();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && ConsuStaminaCooldown > 0)
        {//Stamina
            ComStaminaRegen.SetActive(true);
            UseRunning();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && ConsumableCooldown > 0)
        {//Disparo
            ComPistolRegen.SetActive(true);
            UseCooldown();
        }

        if (Input.GetAxisRaw("Alpha1") == 0)
        {
            isAxisInUse_1 = false;
        }
        if (Input.GetAxisRaw("Alpha1") < 0)
        {
            if (!isAxisInUse_1 && ConsuLifeRegen > 0)
            {
                ComLifeRegen.SetActive(true);
                UseLifeRegen();
                isAxisInUse_1 = true;
            }
        }

        if (Input.GetAxisRaw("Alpha2") == 0)
        {
            isAxisInUse_2 = false;
        }
        if (Input.GetAxisRaw("Alpha2") > 0)
        {
            if (!isAxisInUse_2 && ConsuStaminaCooldown > 0)
            {
                ComStaminaRegen.SetActive(true);
                UseRunning();
                isAxisInUse_2 = true;
            }
        }
        if (Input.GetAxisRaw("Alpha2") < 0)
        {
            if (!isAxisInUse_2 && ConsumableCooldown > 0)
            {
                ComPistolRegen.SetActive(true);
                UseCooldown();
                isAxisInUse_2 = true;
            }
        }
    }

    private void LimitMaxValues() //Limita la cantidad máxima de cada item que puede llevar el jugador.
    {                
        if (ConsumableCooldown > 5)
        {
            ConsumableCooldown = 5;
        }
        if (ConsuLifeRegen > 5)
        {
            ConsuLifeRegen = 5;
        }
        if (ConsuStaminaCooldown > 5)
        {
            ConsuStaminaCooldown = 5;
        }


    }

}
