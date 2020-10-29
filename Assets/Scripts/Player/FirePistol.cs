using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SciFiArsenal
{
    public class FirePistol : MonoBehaviour
    {
        RaycastHit hit;
        [SerializeField] Transform spawnPosition;
        [SerializeField] float speed = 1000;
        [SerializeField] GameObject projectil;
        bool CanShoot;
        PlayerMovement playerMovement;
        [SerializeField] StaminaBar Bar;
        [SerializeField] float AmountEnergy;
        [SerializeField] int damage;

        bool isAxisInUse;

        private void Start()
        {
            playerMovement = PlayerMovement.Instance;
            CanShoot = true; 
        }

        void Update()
        {
            if (Input.GetAxisRaw("Shoot") == 0) isAxisInUse = false;
            if (playerMovement.Aiming)
            {
                if (Input.GetAxisRaw("Shoot") >= 0.5f || Input.GetButtonDown("Shoot")) // Camera.main.ScreenPointToRay(Input.mousePosition) // spawnPosition.position, spawnPosition.forward, out hit, 100f
                {

                    if (!isAxisInUse && CanShoot)
                    {
                        if (Bar.UseStamina(AmountEnergy))
                        {
                            if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
                            {
                                isAxisInUse = true;
                                GameObject projectile = Instantiate(projectil, spawnPosition.position, Quaternion.identity) as GameObject;
                                projectile.transform.LookAt(hit.point);
                                projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
                                projectile.GetComponent<SciFiProjectileScript>().gameObject.layer = gameObject.layer;
                                projectile.GetComponent<SciFiProjectileScript>().impactNormal = hit.normal;
                                projectile.GetComponent<SciFiProjectileScript>().damageAmount = damage;
                            }
                        } 
                    }
                }
            }

            Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction * 100, Color.yellow);
        }

        public void NoEnergy()
        {
            CanShoot = false;
        }
        public void HasEnergy()
        {
            CanShoot = true;
        }
    }
}
