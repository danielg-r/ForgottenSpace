using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    [SerializeField] Slider energyBar;
    public int waitToRegen = 0;
    [SerializeField] int maxEnergy = 100;
    [SerializeField] int cantRegen = 10;
    int currentEnergy;
    public static EnergyBar instance;
    WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    Coroutine regen;

    private void Awake()
    {
        instance = this;
    }

    void Start()
    {
        currentEnergy = maxEnergy;
        energyBar.maxValue = maxEnergy;
        energyBar.value = maxEnergy;
    }

    void Update()
    {
        
    }

    public void UseEnergy(int amount)
    {
        if (currentEnergy - amount >= 0)
        {
            currentEnergy -= amount;
            energyBar.value = currentEnergy;

            if (regen != null)
                StopCoroutine(regen);
            regen = StartCoroutine(regenEnergy());
        }
        else
        {

        }
    }

    IEnumerator regenEnergy()
    {
        yield return new WaitForSeconds(waitToRegen);

        while (currentEnergy < maxEnergy)
        {
            currentEnergy += cantRegen;
            energyBar.value = currentEnergy;
            yield return regenTick;
        }
        regen = null;
    }
}
