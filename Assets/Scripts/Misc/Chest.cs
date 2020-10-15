using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Chest : MonoBehaviour
{
    Interactable interactable;
    [SerializeField] bool currencyOnly;
    [SerializeField] int currency;
    [SerializeField] int platesAmount;
    [SerializeField] int circuitsAmount;

    void Start() {
        interactable = GetComponent<Interactable>();
        interactable.OnInteract.AddListener(Loot);
        interactable.OnInteract.AddListener(ChestSound);
    }

    void ChestSound() {
        AudioManager.Instance.Play("Loot");
    }

    void Loot() {
        if (currencyOnly) {
            CurrencyManager.Instance.AddCurrency(currency);
            Invoke("CurrencyNotification", 1f);
        }
        else {
            CurrencyManager.Instance.AddPlates(platesAmount);
            CurrencyManager.Instance.AddCircuits(circuitsAmount);
            Invoke("LootNotification", 1f);
        }
    }

    void CurrencyNotification() {
        NotificationHandler.Instance.CurrencyAdded($"Has encontrado ${currency} créditos.");
    }

    void LootNotification() {
        if (platesAmount == 0) {
            NotificationHandler.Instance.LootFound($"Has encontrado {circuitsAmount} circuitos");            
        }
        else if (circuitsAmount == 0) {
            NotificationHandler.Instance.LootFound($"Has encontrado {platesAmount} placas");
        }
        else {
            NotificationHandler.Instance.LootFound($"Has encontrado {platesAmount} placas y {circuitsAmount} circuitos");
        }
    }


}
