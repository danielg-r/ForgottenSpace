using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class InventoryManager : MonoBehaviour
{
    public static InventoryManager Instance { get; private set; }

    [SerializeField] GameObject shipSlotHolder;
    [SerializeField] GameObject loreSlotHolder;
    Currency curr;

    private int freeLoreSlots;
    private int freeShipSlots;
    private Transform[] shipSlots;
    private Transform[] loreSlots;
    public int currentCurrency;
    public int shipPieceCount;
    public int currentGunPieces;
    public int currentSuitPieces;


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
        DetectSlots();
        curr = GetComponent<Currency>();
    }

    public void OnTriggerEnter(Collider other) //Interaction test.
    {
        if (other.gameObject.GetComponent<Item>())
        {
            GameObject pickedItem = other.gameObject;

            int it = other.gameObject.GetComponent<Item>().type;
            AddItem(pickedItem, it);

        }
    }

    public void AddItem(GameObject item, int it)
    {
        switch (it)
        {
            case 1:
                {
                    for (int i = 0; i < freeLoreSlots; i++)
                    {
                        if (loreSlots[i].GetComponent<Slot>().isEmpty)
                        {
                            loreSlots[i].GetComponent<Slot>().item = item;
                            loreSlots[i].GetComponent<Slot>().itemIcon = item.GetComponent<Item>().icon;
                            break;
                        }
                    }
                }
                break;

            case 2:
                {

                }
                break;
            case 3:
                {

                    for (int i = 0; i < freeShipSlots; i++)
                    {
                        if (shipSlots[i].GetComponent<Slot>().isEmpty) // && itemAdded == false
                        {
                            shipSlots[i].GetComponent<Slot>().item = item;
                            shipSlots[i].GetComponent<Slot>().itemIcon = item.GetComponent<Item>().icon;
                            shipPieceCount += 1;
                            break;
                        }
                    }
                }
                break;
            case 4:
                {

                }
                break;
            case 5:
                {

                }
                break;
            case 6:
                {

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
