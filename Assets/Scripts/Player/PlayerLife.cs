using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour
{
    public static PlayerLife Instance { get; private set; }

    [SerializeField] Volume vol;
    Vignette vig;
    public float AmountRegen;
    [SerializeField] int waitToRegen;

    [SerializeField] Slider staminaBar;
    [SerializeField] int maxLife;
    float currentLife;

    WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    Coroutine regen;
    Coroutine restarScreen;

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
        currentLife = maxLife;
        staminaBar.maxValue = maxLife;
        staminaBar.value = maxLife;
        vol.profile.TryGet<Vignette>(out vig);
        vig.intensity.value = 0;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
    }

    public void TakeDamage(float amount)
    {
        if (currentLife - amount > 0)
        {
            currentLife -= amount;
            staminaBar.value = currentLife;
            vig.intensity.value += (amount/100);
            AudioManager.Instance.Play("HurtPlayer");

            if (regen != null)
                StopCoroutine(regen);
            regen = StartCoroutine(regenLife());
        }
        else
        {
            if (onPlayerDied != null)
            {
                staminaBar.value = 0;
                StopCoroutine(regen);
                AudioManager.Instance.Play("PlayerDeath");
                onPlayerDied();
            }
        }
    }

    IEnumerator regenLife()
    {
        yield return new WaitForSeconds(waitToRegen);

        while (currentLife < maxLife)
        {
            currentLife += AmountRegen;
            staminaBar.value = currentLife;
            vig.intensity.value -= (AmountRegen/100);
            yield return regenTick;
        }
        regen = null;
    }
}
