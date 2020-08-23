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
    PlayerLife player;
    
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
        agent = GetComponentInParent<NavMeshAgent>();
        currentHealth = maxHealth;
        player = PlayerLife.Instance;
    }

    // Camera.main.ScreenPointToRay(Input.mousePosition)
    void FixedUpdate()
    {
        if (Vector3.Distance(transform.position, player.transform.position) < shootingDistance + 5f) ChaseTarget();
        if (Vector3.Distance(transform.position, player.transform.position) < shootingDistance + 2f) transform.LookAt(player.transform.position + new Vector3(0,1.5f,0));
        if (Physics.Raycast(spawnPosition.position, spawnPosition.forward, out hit, shootingDistance) && !isShooting)
        {
            if(hit.collider.gameObject.tag == "Player")
            {
                StartCoroutine("ShootLaser");       
                isShooting = true;
            }
        }
        else return; 
    }

    void ChaseTarget()
    {
        agent.SetDestination(PlayerLife.Instance.transform.position);
        agent.stoppingDistance = shootingDistance; 
        agent.speed = 2f;
    }

    IEnumerator ShootLaser()
    {
        SpawnLaser();
        yield return new WaitForSeconds(0.5f);
        SpawnLaser();
        yield return new WaitForSeconds(2f);
        StopCoroutine("ShootLaser");
        isShooting = false;
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
        Destroy(deathPS, 2f);
        Destroy(transform.parent.transform.parent.gameObject);
    }
    
}
