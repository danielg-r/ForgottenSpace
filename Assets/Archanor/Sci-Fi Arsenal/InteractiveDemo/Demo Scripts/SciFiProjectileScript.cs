using UnityEngine;
using System.Collections;

namespace SciFiArsenal
{
public class SciFiProjectileScript : MonoBehaviour
{
    public GameObject impactParticle;
    public GameObject projectileParticle;
    public GameObject muzzleParticle;
    public GameObject[] trailParticles;
    [HideInInspector]
    public Vector3 impactNormal; //Used to rotate impactparticle.
    public int damageAmount = 0;
    public GameObject myObject;

    private bool hasCollided = false;
    private bool projectileCreated = false;

    void Start()
    {
        projectileParticle = Instantiate(projectileParticle, transform.position, transform.rotation) as GameObject;
        projectileParticle.transform.parent = transform;
        projectileCreated = true;
        if (muzzleParticle)
        {
            muzzleParticle = Instantiate(muzzleParticle, transform.position, transform.rotation) as GameObject;
            muzzleParticle.transform.rotation = transform.rotation * Quaternion.Euler(180, 0, 0);
            Destroy(muzzleParticle, 1.5f); // Lifetime of muzzle effect.
        }
    }

    void OnCollisionEnter(Collision hit)
    {
        if (gameObject.CompareTag("Projectile") && hit.gameObject.CompareTag("Projectile"))
        {
            Debug.Log("Ignorando collision");
            Physics.IgnoreCollision(GetComponent<Collider>(), hit.gameObject.GetComponent<Collider>(),true);
            hasCollided = false;
        }

        if (!hasCollided)
        {
            impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;

            if (hit.gameObject.GetComponent<IDamageable>() != null)
            {                
                // else
                // {
                    hit.gameObject.GetComponent<IDamageable>().TakeDamage(damageAmount);
                    //impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
                    hasCollided = true;
                //}                    
            }
            else
            {
                //impactParticle = Instantiate(impactParticle, transform.position, Quaternion.FromToRotation(Vector3.up, impactNormal)) as GameObject;
                hasCollided = true;
            }
 
            foreach (GameObject trail in trailParticles)
            {
                GameObject curTrail = transform.Find(projectileParticle.name + "/" + trail.name).gameObject;
                curTrail.transform.parent = null;
                Destroy(curTrail, 3f);
            }

            if (projectileCreated) Destroy(impactParticle, 3f);
            if (projectileCreated) Destroy(projectileParticle, 5f);
            Destroy(gameObject);
			
			ParticleSystem[] trails = GetComponentsInChildren<ParticleSystem>();
            //Component at [0] is that of the parent i.e. this object (if there is any)
            for (int i = 1; i < trails.Length; i++)
            {
				
                ParticleSystem trail = trails[i];
				
				if (trail.gameObject.name.Contains("Trail"))
				{
				trail.transform.SetParent(null);
				Destroy(trail.gameObject, 2f);
				}
            }
        }
        // Destroy(impactParticle, 3f);
        // Destroy(projectileParticle, 5f);
        // Destroy(gameObject);            
    }
}
}
