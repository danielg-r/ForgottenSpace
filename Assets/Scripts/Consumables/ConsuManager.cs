using System.Collections;
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

    void Update()
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
