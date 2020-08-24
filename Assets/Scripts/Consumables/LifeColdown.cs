using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeColdown : MonoBehaviour
{
    [SerializeField] float AmountRegenOriginal;
    [SerializeField] float AmountRegenPlus;

    float Duration = 15f;


    void OnEnable() //Se llama esta función cuando el gameobject se pone activo.
    {
        AmountRegenOriginal = PlayerLife.Instance.AmountRegen;
        PlayerLife.Instance.AmountRegen = AmountRegenPlus + PlayerLife.Instance.AmountRegen;

        StartCoroutine(ActiveTimeRegen());
    }

    void Disable()
    {
        PlayerLife.Instance.AmountRegen = AmountRegenOriginal;
        this.gameObject.SetActive(false);
    }

    IEnumerator ActiveTimeRegen()
    {        
        yield return new WaitForSeconds(Duration);
        Disable();
    }

}
