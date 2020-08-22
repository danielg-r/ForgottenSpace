using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SciFiArsenal;

public class DroneAttack : MonoBehaviour, IDamageable
{
    RaycastHit hit;
    Ray ray;
    public GameObject prefab;
    public Transform spawnPosition;
    Vector3 dispersion; 
    [SerializeField] float maxHealth; 
    [SerializeField] float currentHealth;
    [SerializeField] GameObject deathFX;
    [HideInInspector]
	public float speed = 1000;

    void Start()
    {
        currentHealth = maxHealth;
    }

    // Camera.main.ScreenPointToRay(Input.mousePosition)
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {		
            dispersion = new Vector3(Random.Range(-5f,5f), Random.Range(-5f, 5f), 0);
            if (Physics.Raycast(spawnPosition.position, spawnPosition.forward, out hit, 100f))
            {
                GameObject projectile = Instantiate(prefab, spawnPosition.position, spawnPosition.rotation) as GameObject;  
                projectile.transform.eulerAngles = spawnPosition.rotation.eulerAngles + dispersion; 
                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
                projectile.GetComponent<SciFiProjectileScript>().impactNormal = hit.normal;
            }
        }        
    }

    public void TakeDamage(int amount)
    {
        currentHealth -= amount;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        GameObject deathPS = Instantiate(deathFX, transform.position, Quaternion.identity);
        deathPS.transform.localScale = Vector3.one * 0.5f;
        Destroy(gameObject);
    }
    
}
