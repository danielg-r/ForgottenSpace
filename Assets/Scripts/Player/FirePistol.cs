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
        [SerializeField] float Cooldown;
        float nextTime;
        PlayerMovement playerMovement;

        private void Start()
        {
            playerMovement = PlayerMovement.Instance;
        }

        void Update()
        {
            if (playerMovement.Aiming)
            {
                if (CanShoot)
                {
                    if (Input.GetKeyDown(KeyCode.Mouse0))
                    {

                        if (Physics.Raycast(Camera.main.ScreenPointToRay(Input.mousePosition), out hit, 100f))
                        {
                            GameObject projectile = Instantiate(projectil, spawnPosition.position, Quaternion.identity) as GameObject;
                            projectile.transform.LookAt(hit.point);
                            projectile.GetComponent<Rigidbody>().AddForce(projectile.transform.forward * speed);
                            projectile.GetComponent<SciFiProjectileScript>().impactNormal = hit.normal;
                        }
                        CanShoot = false;
                        nextTime = Time.time + Cooldown;
                    }
                } 
            }

            if (Time.time >= nextTime)
            {
                CanShoot = true;
            }

            Debug.DrawRay(Camera.main.ScreenPointToRay(Input.mousePosition).origin, Camera.main.ScreenPointToRay(Input.mousePosition).direction * 100, Color.yellow);
        }
    }
}
