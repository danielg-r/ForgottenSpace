using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.UI;

public class PlayerLife : MonoBehaviour, IDamageable
{
    public static PlayerLife Instance { get; protected set; }

    [SerializeField] Volume vol;
    Vignette vig;
    public float AmountRegen;
    [SerializeField] int waitToRegen;

    [SerializeField] Slider staminaBar;
    [SerializeField] int maxLife;
    float currentLife;

    WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    Coroutine regen;
    Animator animator;

    public delegate void PlayerEvents();
    public event PlayerEvents onPlayerRespawned;
    public event PlayerEvents onPlayerDied;
    [HideInInspector] public bool isDead;

    private void OnEnable()
    {
        if (regen != null)
            StopCoroutine(regen);
        regen = StartCoroutine(regenLife());
    }

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O)) {
            Die();
        }
    }

    void Start()
    {
        currentLife = maxLife;
        staminaBar.maxValue = maxLife;
        staminaBar.value = maxLife;
        vol.profile.TryGet<Vignette>(out vig);
        vig.intensity.value = 0;
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        if (GetCharacter.Instance.IsMale == true) { AudioManager.Instance.Play("HurtPlayer"); }
        else { AudioManager.Instance.Play("FemaleHurt"); }
        if (currentLife - amount > 0)
        {
            currentLife -= amount;
            staminaBar.value = currentLife;
            vig.intensity.value += ((float)amount/100);

            if (regen != null)
                StopCoroutine(regen);
            regen = StartCoroutine(regenLife());
        }
        else
        {
            Die();
        }
    }

    public void Die() {
        if (onPlayerDied != null) {
            isDead = true;
            staminaBar.value = 0;
            StopAllCoroutines();
            //StopCoroutine(regen);
            if (GetCharacter.Instance.IsMale == true) { AudioManager.Instance.Play("PlayerDeath"); }
            else { AudioManager.Instance.Play("FemaleDeath"); }
            onPlayerDied();
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

    public void Respawn() {
        if (onPlayerRespawned != null) {
            animator.applyRootMotion = true;
            animator.SetTrigger("Respawn");
            isDead = false;
            staminaBar.value = maxLife;
            currentLife = maxLife;
            vig.intensity.value = 0;            
            onPlayerRespawned();        
        }
    }
}
