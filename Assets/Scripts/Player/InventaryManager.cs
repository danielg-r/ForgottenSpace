using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventaryManager : MonoBehaviour
{     
    private float t1;
    private float duration = 5f;

    public int coin { get; private set; }
    public int cooldown { get; private set; }
    public int lifeRegen { get; private set; }
    public int runCooldown { get; private set; }

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
        cooldown--;        
    }
    public void RecolectCooldown(int _coldown)
    {
        cooldown += _coldown;
    }
    //---------------------
    public void UseLifeRegen()
    {
        lifeRegen--;
    }
    public void RecolectLifeRegen(int _liferegen)
    {
        lifeRegen += _liferegen;
    }
    //----------------------
    public void UseRunning()
    {
        runCooldown--;
    }
    public void RecolectRunning(int _runCooldown)
    {
        runCooldown += _runCooldown;
    }
    #endregion


    private void LimitMaxValues() //Limita la cantidad máxima de cada item que puede llevar el jugador.
    {        
        if (coin > 99)
        {
            coin = 99;
        }
        if (cooldown > 5)
        {
            cooldown = 5;
        }
        if (lifeRegen > 5)
        {
            lifeRegen = 5;
        }

    }

}
