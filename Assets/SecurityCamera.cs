using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class SecurityCamera : MonoBehaviour, IDamageable
{
    [Header("Attributes")]
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;
    [SerializeField] int deathTimer;
    [SerializeField] GameObject deathFX;
    [SerializeField] GameObject detectionSystem;
    [SerializeField] Collider deathCollider;
    [Header("Events")]
    public UnityEvent OnDisable; 
    public UnityEvent OnEnable; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) Deactivate();
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Deactivate();
    }

    void Deactivate()
    {
        Disable();
        //DoTween para que apunte hacia abajo
        //Audio chido 
        StartCoroutine("DeactivationTimer");
    }

    void Disable()
    {
        AudioManager.Instance.Play("CameraSparks");
        OnDisable.Invoke();
        detectionSystem.SetActive(false);
        deathCollider.enabled = false;
        deathFX.SetActive(true);
    }

    void Enable()
    {
        OnEnable.Invoke();
        detectionSystem.SetActive(true);
        deathCollider.enabled = true;
        deathFX.SetActive(false);
    }

    IEnumerator DeactivationTimer()
    {
        deathCollider.enabled = false;        
        yield return new WaitForSeconds(deathTimer);
        currentHealth = maxHealth;
        Enable();
    }
}
