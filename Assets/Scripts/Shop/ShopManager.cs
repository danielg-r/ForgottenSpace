using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public static ShopManager Instance { get; private set; }

    public int StaminaValue;
    public int EnergyValue;
    public int LifeValue;

    [SerializeField] int CurrUsed;
    [SerializeField] int CurrLimit;

    public bool hasVisitedShop;

    ConsuManager consuManager;
    InventoryManager inventoryManager;
    CurrencyManager currencymanager;

    [SerializeField] GameObject HotBar;

    [Header("Texto Botones")]
    [SerializeField] Text Texto1;
    [SerializeField] Text Texto2;
    [SerializeField] Text Texto3;


    [Header("Botones y Maricadas de agotado")]
    [SerializeField] public Button[] buyButtons;
    [SerializeField] RawImage[] soldImages;
    [SerializeField] public TextMeshProUGUI[] InvLimnit;
    public bool OutInv = false;



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
        consuManager = ConsuManager.Instance;
        inventoryManager = InventoryManager.Instance;
        currencymanager = CurrencyManager.Instance;
    }



    public void BuyStamina()
    {
        if (inventoryManager.currentCurrency >= StaminaValue && (consuManager.ConsuStaminaCooldown < 5) && (CurrLimit >= CurrUsed) )
        {
            consuManager.RecolectRunning(1);
            currencymanager.UseCurrency(StaminaValue);
            AudioManager.Instance.Play("Click");
            CurrUsed += StaminaValue;
            TopLimit();            
        }
        if (consuManager.ConsuStaminaCooldown >= 5)
        {
            buyButtons[1].interactable = false;
            InvLimnit[1].gameObject.SetActive(true);
        }
    }

    public void BuyEnergy()
    { 
        if (inventoryManager.currentCurrency >= EnergyValue && consuManager.ConsumableCooldown < 5 && (CurrLimit >= CurrUsed) )
        {
            consuManager.RecolectCooldown(1);
            currencymanager.UseCurrency(EnergyValue);
            AudioManager.Instance.Play("Click");
            CurrUsed += EnergyValue;
            TopLimit();
        }
        if (consuManager.ConsumableCooldown >= 5)
        {
            buyButtons[2].interactable = false;
            InvLimnit[2].gameObject.SetActive(true);
        }
    }

    public void BuyLife()
    {
        if (inventoryManager.currentCurrency >= LifeValue && consuManager.ConsuLifeRegen < 5 && (CurrLimit >= CurrUsed) )
        {
            consuManager.RecolectLifeRegen(1);
            currencymanager.UseCurrency(LifeValue);
            AudioManager.Instance.Play("Click");
            CurrUsed += LifeValue;
            TopLimit();
        }
        if (consuManager.ConsuLifeRegen >= 5)
        {
            buyButtons[0].interactable = false;
            InvLimnit[0].gameObject.SetActive(true);
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


    void TopLimit()
    {
        if (CurrLimit < CurrUsed)
        {
            for (int i = 0; i < buyButtons.Length; i++)
            {
                buyButtons[i].interactable = false;
                soldImages[i].gameObject.SetActive(true);
                OutInv = true;
            }
        }
    }


    public void ActiveHotBar()
    {
        hasVisitedShop = true;
        HotBar.SetActive(true);
    }


}
