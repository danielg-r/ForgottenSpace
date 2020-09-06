using SciFiArsenal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    public static CraftSystem Instance { get; private set; }

    #region Pistol
    [Header("Pistola")]
    public int CircuitsToPistol = 3; //Valor interno
    public int PlatesToPistol = 2; //Valor interno
    public bool CanCraftPistol = true;
    bool ICraftPistol=false;
    #endregion


    #region Armadura
    [Header("Armadura")]
    public int CircuitsToArmor = 2; //Valor interno
    public int PlatesToArmor = 3; //Valor interno
    public bool CanCraftArmor = true;
    bool ICraftArmor = false;
    public GameObject Armor;
    #endregion

    #region Ship
    [Header("Ship")]
    public int CircuitsToShip = 4; //Valor interno
    public int PlatesToShip = 4; //Valor interno
    public bool CanCraftShip = true;
    bool ICraftShip = false;
    //public GameObject Ship;
    #endregion

    public delegate void OnCurrencySpent();
    public event OnCurrencySpent onCurrSpent;
    InventoryManager inventoryManager;


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
        inventoryManager = InventoryManager.Instance;
        
    }

    public void Craft()
    {
        if (CanCraftPistol && ( ICraftPistol == false) && inventoryManager.currentGunPieces >= CircuitsToPistol && inventoryManager.currentSuitPieces >= PlatesToPistol )
        {
            ActivatePistol.Instance.Activate();
            inventoryManager.currentGunPieces -= CircuitsToPistol;
            inventoryManager.currentSuitPieces -= PlatesToPistol;
            onCurrSpent();
            AudioManager.Instance.Play("Click");            
            ICraftPistol = true;
            
        }
    }

    public void CraftArmor()
    {
        if (CanCraftArmor && ICraftArmor == false  && inventoryManager.currentGunPieces >= CircuitsToArmor && inventoryManager.currentSuitPieces >= PlatesToArmor)
        {            
            inventoryManager.currentGunPieces -= CircuitsToArmor;
            inventoryManager.currentSuitPieces -= PlatesToArmor;
            onCurrSpent();
            AudioManager.Instance.Play("Click");
            ICraftArmor = true;
            Armor.gameObject.SetActive(true);
        }
    }


    public void CraftShip()
    {
        if (CanCraftShip && ICraftShip == false && inventoryManager.currentGunPieces >= CircuitsToShip && inventoryManager.currentSuitPieces >= PlatesToShip)
        {
            inventoryManager.currentGunPieces -= CircuitsToShip;
            inventoryManager.currentSuitPieces -= PlatesToShip;
            onCurrSpent();
            AudioManager.Instance.Play("Click");
            ICraftShip = true;
            //Ship.gameObject.SetActive(true); BUSCAR LA NAVE
        }
    }

}
