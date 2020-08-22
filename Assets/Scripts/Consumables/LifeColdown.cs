using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeColdown : MonoBehaviour
{
    [SerializeField] PlayerLife LBar;
    [SerializeField] float AmountRegenOriginal;
    [SerializeField] int AmountRegenPlus;

    float Duration = 15f;


    void OnEnable() //Se llama esta función cuando el gameobject se pone activo.
    {
        LBar = GetComponent<PlayerLife>();
        AmountRegenOriginal = LBar.AmountRegen;
        LBar.AmountRegen = AmountRegenPlus;

        StartCoroutine(ActiveTimeRegen());
    }

    void Disable()
    {
        LBar.AmountRegen = AmountRegenOriginal;
        this.gameObject.SetActive(false);
    }

    IEnumerator ActiveTimeRegen()
    {        
        yield return new WaitForSeconds(Duration);
        Disable();
    }

}
