using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public delegate void OnItemAdded();
    public event OnItemAdded onItemAdded;

    public delegate void OnItemUsed();
    public event OnItemUsed onItemUsed;
    public static ItemManager Instance { get; private set; }

    public int itemcooldown; //{ get; private set; }
    public int itemlifeRegen; //{ get; private set; }
    public int itemRunCooldown; // { get; private set; }
    
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
        itemcooldown--;
        onItemAdded();
    }
    public void RecolectCooldown(int _coldown)
    {
        itemcooldown += _coldown;
        onItemAdded();
    }
    //---------------------
    public void UseLifeRegen()
    {
        itemlifeRegen--;
        onItemAdded();
    }
    public void RecolectLifeRegen(int _liferegen)
    {
        itemlifeRegen += _liferegen;
        onItemAdded();
    }
    //----------------------
    public void UseRunning()
    {
        itemRunCooldown--;
        onItemAdded();
    }
    public void RecolectRunning(int _runCooldown)
    {
        itemRunCooldown += _runCooldown;
        onItemAdded();

    }
    #endregion


    private void LimitMaxValues() //Limita la cantidad máxima de cada item que puede llevar el jugador.
    {                
        if (itemcooldown > 5)
        {
            itemcooldown = 5;
        }
        if (itemlifeRegen > 5)
        {
            itemlifeRegen = 5;
        }
        if (itemRunCooldown > 5)
        {
            itemRunCooldown = 5;
        }


    }

}
