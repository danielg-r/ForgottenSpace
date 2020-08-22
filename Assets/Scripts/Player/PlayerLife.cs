﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class PlayerLife : MonoBehaviour, IDamageable
{
    public static PlayerLife Instance { get; private set; }

    [SerializeField] Volume vol;
    Vignette vig;
    public int AmountRegen;
    [SerializeField] int waitToRegen;
    float currentLife;

    WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    Coroutine regen;

    public delegate void OnPlayerDied();
    public event OnPlayerDied onPlayerDied;

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

    void Start()
    {
        vol.profile.TryGet<Vignette>(out vig);
        vig.intensity.value = 0;
    }

    public void TakeDamage(int amount)
    {
        if (currentLife + amount / 100 <= 1)
        {
            currentLife += amount;
            vig.intensity.value = currentLife;

            if (regen != null)
                StopCoroutine(regen);
            regen = StartCoroutine(regenLife());
        }
        else
        {
            if (onPlayerDied != null)
            {
                onPlayerDied();
            }
        }
    }

    IEnumerator regenLife()
    {
        yield return new WaitForSeconds(waitToRegen);

        while (currentLife >= 0)
        {
            currentLife -= AmountRegen/100;
            vig.intensity.value = currentLife;
            yield return regenTick;
        }
        regen = null;
    }
}
