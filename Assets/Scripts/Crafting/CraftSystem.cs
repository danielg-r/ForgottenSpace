using SciFiArsenal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;

public class CraftSystem : MonoBehaviour
{
    public static CraftSystem Instance { get; private set; }
    [SerializeField] ModalWindowManager loreScreen;

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
    public int PiecesToShip = 5; //Valor interno
    public bool CanCraftShip = true;
    bool ICraftShip = false;
    //public GameObject Ship;
    #endregion

    public delegate void OnCurrencySpent();
    public event OnCurrencySpent onCurrSpent;
    InventoryManager inventoryManager;

    [Header("Pistol Bar")]
    [SerializeField] GameObject PistolBar;

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
        if (CanCraftPistol && ( ICraftPistol == false) && inventoryManager.currentCircuits >= CircuitsToPistol && inventoryManager.currentPlates >= PlatesToPistol )
        {
            ActivatePistol.Instance.Activate();
            inventoryManager.currentCircuits -= CircuitsToPistol;
            inventoryManager.currentPlates -= PlatesToPistol;
            onCurrSpent();
            AudioManager.Instance.Play("Click");            
            ICraftPistol = true;
            PistolBar.SetActive(true);
            loreScreen.OpenWindow();
            ObjectiveManager.Instance.SetCurrentObjective($"Recupera las piezas de tu nave para evacuar la estación. (0/4)");
             // Mostrar la ventana de advertencia            
        }
    }

    public void CraftArmor()
    {
        if (CanCraftArmor && ICraftArmor == false  && inventoryManager.currentCircuits >= CircuitsToArmor && inventoryManager.currentPlates >= PlatesToArmor)
        {            
            inventoryManager.currentCircuits -= CircuitsToArmor;
            inventoryManager.currentPlates -= PlatesToArmor;
            onCurrSpent();
            AudioManager.Instance.Play("Click");
            ICraftArmor = true;
            Armor.gameObject.SetActive(true);
        }
    }


    public void CraftShip()
    {
        if (CanCraftShip && ICraftShip == false && (inventoryManager.shipPieceCount == PiecesToShip) )
        {                    
            onCurrSpent();
            AudioManager.Instance.Play("Click");
            ICraftShip = true;
            //Ship.gameObject.SetActive(true); BUSCAR LA NAVE
        }
    }



    //METODOS PARA EL CURSOR
    public void ShowCursor()
    {
        CursorManager.Instance.ShowCursor();
    }
    public void HideCursor()
    {
        CursorManager.Instance.HideCursor();
    }



}
