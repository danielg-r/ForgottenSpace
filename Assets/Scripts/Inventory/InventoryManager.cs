using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField] GameObject shipSlotHolder;
    [SerializeField] GameObject loreSlotHolder;
    Currency curr;

    public int freeLoreSlots;
    private int freeShipSlots;
    private Transform[] shipSlots;
    public Transform[] loreSlots;
    public ModalWindowManager[] windowArray;
    public int currentCurrency;
    public int shipPieceCount;
    public int currentCircuits;
    public int currentPlates;


    public delegate void OnCurrencyAdded();
    public event OnCurrencyAdded onPiecesAdded;
    

    bool itemAdded;

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

        freeLoreSlots = loreSlotHolder.transform.childCount;
        freeShipSlots = shipSlotHolder.transform.childCount;
        loreSlots = new Transform[freeLoreSlots];
        shipSlots = new Transform[freeShipSlots];
        windowArray = new ModalWindowManager[9];
        DetectSlots();
        curr = GetComponent<Currency>();
    }

    public void AddItem(Item item)
    {
        int it = item.type;
        switch (it)
        {
            case 1:
                {
                    for (int i = 0; i < freeLoreSlots; i++)
                    {
                        if (loreSlots[i].GetComponent<Slot>().isEmpty)
                        {
                            loreSlots[i].GetComponent<Slot>().item = item;
                            loreSlots[i].GetComponent<Slot>().itemIcon = item.icon;
                            windowArray[i] = item.loreWindow;
                            break;
                        }
                    }
                }
                break;

            case 2:
                {

                    for (int i = 0; i < freeShipSlots; i++)
                    {
                        if (shipSlots[i].GetComponent<Slot>().isEmpty)
                        {
                            shipSlots[i].GetComponent<Slot>().item = item;
                            shipSlots[i].GetComponent<Slot>().itemIcon = item.icon;
                            shipPieceCount += 1;
                            onPiecesAdded();
                            item.gameObject.SetActive(false);
                            break;
                        }
                    }
                }
                break;
        }
    }
    void DetectSlots()
    {
        for (int i = 0; i < freeShipSlots; i++)
        {
            shipSlots[i] = shipSlotHolder.transform.GetChild(i);
        }

        for (int i = 0; i < freeLoreSlots; i++)
        {
            loreSlots[i] = loreSlotHolder.transform.GetChild(i);
        }
    }
}
