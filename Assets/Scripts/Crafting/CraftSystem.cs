using SciFiArsenal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Assertions.Must;
using UnityEngine.Events;

public class CraftSystem : MonoBehaviour
{
    public static CraftSystem Instance { get; private set; }
    [SerializeField] ModalWindowManager loreScreen;
   

    #region Pistol
    [Header("Pistola")]
    public int CircuitsToPistol = 3; //Valor interno
    public int PlatesToPistol = 2; //Valor interno
    public bool CanCraftPistol = true;
    public bool ICraftPistol=false;
    #endregion


    #region Ship
    [Header("Ship")]
    public int PiecesToShip = 5; //Valor interno
    public bool CanCraftShip = true;
    bool CraftedShip = false;
    //public GameObject Ship;
    #endregion

    public delegate void OnCurrencySpent();
    public event OnCurrencySpent onCurrSpent;

    public delegate void OnShipCrafted();
    public event OnShipCrafted onShipCrafted;

    InventoryManager inventoryManager;

    [Header("Pistol Bar")]
    [SerializeField] GameObject PistolBar;


    [SerializeField] private TextMeshProUGUI buttonText;
    [SerializeField] public GameObject soldoutImage;

    [Header("MOTOR")]
    [SerializeField] Item motor;


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
            ObjectiveManager.Instance.SetCurrentObjective($"Recupera las piezas de tu nave para evacuar la estación. (0/5)", true);
            // Mostrar la ventana de advertencia    
            buttonText.text = "<color=red> AGOTADO </color>";
            soldoutImage.SetActive(true);
        }
    }



    public void CraftShip()
    {
        if (CanCraftShip && CraftedShip == false && (inventoryManager.shipPieceCount == PiecesToShip) && (inventoryManager.currentCurrency >= 25))
        {                    
            onCurrSpent();
            AudioManager.Instance.Play("Click");
            CraftedShip = true;
            InventoryManager.Instance.AddItem(motor);
            onShipCrafted();
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
