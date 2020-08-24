using SciFiArsenal;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{

    public static CraftSystem Instance { get; private set; }

    public int necessaryPiecesAToPistol = 3; //Valor interno
    public int necessaryPiecesBToPistol = 2; //Valor interno

    public bool CanCraft = false;
    private bool ItCrafted = false;

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
        ItCrafted = false;
        ActivatePistol.Instance.Deactivate();
    }

    public void Update()
    {
        if ( inventoryManager.currentGunPieces >= necessaryPiecesAToPistol && inventoryManager.currentSuitPieces >= necessaryPiecesBToPistol)
        {
            CanCraft = true;
        }
        else
        {
            CanCraft = false;
            
        }

        if (ItCrafted == false)
        {
            //ActivatePistol.Instance.Deactivate();
        }
    }

    public void Craft()
    {
        if (CanCraft)
        {
            if (inventoryManager.currentGunPieces >= necessaryPiecesAToPistol && inventoryManager.currentSuitPieces >= necessaryPiecesBToPistol)
            {
                ActivatePistol.Instance.Activate();
                inventoryManager.currentGunPieces -= necessaryPiecesAToPistol;
                inventoryManager.currentSuitPieces -= necessaryPiecesBToPistol;
                onCurrSpent();
                AudioManager.Instance.Play("Click");
                CanCraft = false;
                ItCrafted = true;
            }
        }
    }
}
