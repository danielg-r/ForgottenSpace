using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    public static ItemManager Instance { get; private set; }

    public int itemcooldown{ get; private set; }
    public int itemlifeRegen { get; private set; }
    public int itemRunCooldown { get; private set; }
        
    [SerializeField] Player player;

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

        itemcooldown++;
        itemlifeRegen++;
        itemRunCooldown++;

        player = Player.Instance;
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
    }
    public void RecolectCooldown(int _coldown)
    {
        itemcooldown += _coldown;
    }
    //---------------------
    public void UseLifeRegen()
    {
        itemlifeRegen--;
    }
    public void RecolectLifeRegen(int _liferegen)
    {
        itemlifeRegen += _liferegen;
    }
    //----------------------
    public void UseRunning()
    {
        itemRunCooldown--;
    }
    public void RecolectRunning(int _runCooldown)
    {
        itemRunCooldown += _runCooldown;
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
