using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SciFiArsenal;

public class Turret : MonoBehaviour
{
    RaycastHit hit;
    Ray ray;
    public GameObject prefab;
    public Transform spawnPosition1;
    public Transform spawnPosition2;

    Vector3 dispersion;
    PlayerLife player;
    [SerializeField] float shootInterval;
    [SerializeField] int damage = 0;
    [HideInInspector]
	public float speed = 1000;
    public bool isShooting = false;

    void Start()
    {
        player = PlayerLife.Instance;
    }

    public void Disable()
    {
        StopAllCoroutines();
        GetComponentInChildren<Viewcone>().gameObject.SetActive(false);
        GetComponentInChildren<Light>().intensity = 0;
        this.enabled = false;        
        //Todo: Un sonidito, un dotweensito, unas particulitas
    }

    public void StartShooting()
    {
        print("Player detected started shooting");
        isShooting = true;
        if (isShooting) StartCoroutine("ShootLaser");
    }
    public void StopShooting()
    {
        print("Stopped shooting");
        isShooting = false;
        StopCoroutine("ShootLaser");
        transform.rotation = new Quaternion(0,0,0,0);
    }

    IEnumerator ShootLaser()
    {
        transform.LookAt(player.transform.position + new Vector3(0,1f,0));        
        while (isShooting)
        {
            SpawnLaser();
            yield return new WaitForSeconds(shootInterval);
            if (player.isDead) isShooting = false;
            transform.LookAt(player.transform.position + new Vector3(0,1f,0));
        }
        StopCoroutine("ShootLaser");
    }

    void SpawnLaser()
    {
        dispersion = new Vector3(Random.Range(-0.2f,0.2f), Random.Range(-0.2f, 0.2f), 0);
        GameObject projectile = Instantiate(prefab, spawnPosition1.position + new Vector3(0,0,0.2f), spawnPosition1.rotation) as GameObject;
        projectile.transform.eulerAngles = spawnPosition1.rotation.eulerAngles + dispersion; 
        projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
        projectile.GetComponent<SciFiProjectileScript>().gameObject.layer = gameObject.layer;
        projectile.GetComponent<SciFiProjectileScript>().damageAmount = damage;
        projectile.GetComponent<SciFiProjectileScript>().impactNormal = hit.normal;
        GameObject projectile2 = Instantiate(prefab, spawnPosition2.position+ new Vector3(0,0,-0.2f), spawnPosition2.rotation) as GameObject;
        projectile2.transform.eulerAngles = spawnPosition2.rotation.eulerAngles + dispersion; 
        projectile2.GetComponent<Rigidbody>().AddForce(projectile2.transform.forward * speed);
        projectile2.GetComponent<SciFiProjectileScript>().gameObject.layer = gameObject.layer;
        projectile2.GetComponent<SciFiProjectileScript>().damageAmount = damage;
        projectile2.GetComponent<SciFiProjectileScript>().impactNormal = hit.normal;
    }
}
