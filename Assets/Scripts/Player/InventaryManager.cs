using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaryManager : MonoBehaviour
{     
    private float t1;
    private float duration = 5f;

    public int coin { get; private set; }
    public int itemcooldown { get; private set; }
    public int itemlifeRegen { get; private set; }
    public int itemRunCooldown { get; private set; }

    public bool staminaBust = false;
    [SerializeField] Player player;

    private void Start()
    {        
        LimitMaxValues();
        player = Player.Instance;
    }

    void Update()
    {
        LimitMaxValues();        

        t1 += Time.deltaTime;
        if (t1 >= duration)
        {
            staminaBust = false;
        }
    }


    #region Use & Recolect
    public void UseCoin()
    {
        coin--;
    }
    public void RecolectCoin(int _coin)
    {
        coin += _coin;
    }
    //--------------------
    public void UseCooldown()
    {
        staminaBust = true;
        t1 = 0f;
        itemcooldown--;        
    }
    public void RecolectCooldown(int _coldown)
    {
        itemcooldown += _coldown;
    }
    //---------------------
    public void UseLifeRegen()
    {
        itemRunCooldown--;
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
        if (coin > 99)
        {
            coin = 99;
        }
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
