using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Animator anim;
    [SerializeField] CinemachineFreeLook camara;
    [SerializeField] float Aim = 15, normalView = 40;

    public float stamina = 5f;
    public float maxStamina = 5f;    

    public void Start()
    {
        player = Player.Instance;
    }
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            camara.m_Lens.FieldOfView = Aim;
            anim.SetBool("Aiming", true);
            anim.SetBool("Running", false);
        }
        else if (Input.GetButton("Fire3") && stamina > 0f)
        {
            camara.m_Lens.FieldOfView = normalView;
            anim.SetBool("Running", true);
            anim.SetBool("Aiming", false);
            stamina -= Time.deltaTime;
        }
        else
        {
            if(stamina < maxStamina)
            {
                stamina += Time.deltaTime;
            }
            if (stamina < maxStamina && player.GetComponent<InventaryManager>().staminaBust == true)
            {
                stamina += 2*Time.deltaTime;
            }
            camara.m_Lens.FieldOfView = normalView;
            anim.SetBool("Running", false);
            anim.SetBool("Aiming", false);
        }

        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
    }
}
