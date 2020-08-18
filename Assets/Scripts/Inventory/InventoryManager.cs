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
        //currentCurrency = 0;
    }

    //public void OnTriggerEnter(Collider other) //Interaction test.
    //{
        //if (other.gameObject.GetComponent<Item>())
        //{
        //    GameObject pickedItem = other.gameObject;
            
        //    int it = other.gameObject.GetComponent<Item>().type;
        //    AddItem(pickedItem, it);
            
        //}
        //if (other.gameObject.GetComponent<Currency>())
        //{
        //    int curr = other.gameObject.GetComponent<Currency>().currencyAmount;
        //    AddCurrency(curr);
        //}
    //}

    //public void OnTriggerExit(Collider other)
    //{
    //    if (other.tag == "Item")
    //    {
    //        itemAdded = false;
    //    }
    //}

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
                            //itemAdded = true;
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
                            //itemAdded = true;
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

    public void AddCurrency(int curr)
    {
        //if (it == 1)
        //{
        currentCurrency += curr;
        Debug.Log("Currency obtained");
        //}
    }

    public void SpendCurrency()
    {

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

    public void CollectCurrency()
    {

    }
}
