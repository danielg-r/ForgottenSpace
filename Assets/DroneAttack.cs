using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using SciFiArsenal;

public class DroneAttack : MonoBehaviour, IDamageable
{
    RaycastHit hit;
    Ray ray;
    public GameObject prefab;
    public Transform spawnPosition;
    Vector3 dispersion; 
    NavMeshAgent agent;
    
    [SerializeField] LayerMask playerLayer;
    [SerializeField] float maxHealth; 
    [SerializeField] float currentHealth;
    [SerializeField] GameObject deathFX;
    [SerializeField] int damage = 0;
    [SerializeField] float shootingDistance = 10f;
    [HideInInspector]
	public float speed = 1000;
    bool isShooting = false;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        currentHealth = maxHealth;
    }

    // Camera.main.ScreenPointToRay(Input.mousePosition)
    void FixedUpdate()
    {
        if (Physics.Raycast(spawnPosition.position, spawnPosition.forward, out hit, shootingDistance, playerLayer) && !isShooting)
        {	
            StartCoroutine("ShootLaser");       
            isShooting = true;
        }        
    }

    IEnumerator ShootLaser()
    {
        SpawnLaser();
        yield return new WaitForSeconds(0.3f);
        SpawnLaser();
        yield return new WaitForSeconds(0.3f);
        SpawnLaser();
        yield return new WaitForSeconds(1f);
        isShooting = false;
        StopCoroutine("ShootLaser");
    }

    void SpawnLaser()
    {
        dispersion = new Vector3(Random.Range(-5f,5f), Random.Range(-5f, 5f), 0);
        GameObject projectile = Instantiate(prefab, spawnPosition.position, spawnPosition.rotation) as GameObject;
        projectile.transform.eulerAngles = spawnPosition.rotation.eulerAngles + dispersion; 
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
        projectile.GetComponent<SciFiProjectileScript>().gameObject.layer = gameObject.layer;
        projectile.GetComponent<SciFiProjectileScript>().damageAmount = damage;
        projectile.GetComponent<SciFiProjectileScript>().impactNormal = hit.normal;
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
