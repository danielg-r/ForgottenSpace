using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] CinemachineFreeLook camara;
    [SerializeField] float Aim = 15, normalView = 40;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            if (camara.m_Lens.FieldOfView > Aim)
            {
                camara.m_Lens.FieldOfView -= Time.time;
            }
            anim.SetBool("Aiming", true);
            anim.SetBool("Running", false);
        }
        else if (Input.GetButton("Fire3"))
        {
            if (camara.m_Lens.FieldOfView < normalView)
            {
                camara.m_Lens.FieldOfView += Time.time;
            }
            anim.SetBool("Running", true);
            anim.SetBool("Aiming", false);
        }
        else
        {
            if (camara.m_Lens.FieldOfView < normalView)
            {
                camara.m_Lens.FieldOfView += Time.time;
            }
            anim.SetBool("Running", false);
            anim.SetBool("Aiming", false);
        }
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
    }
}
