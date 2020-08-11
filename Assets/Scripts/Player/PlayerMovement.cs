using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Animator anim;
    [SerializeField] CinemachineFreeLook camara;
    [SerializeField] float Aim = 15f, normalView = 40f;

    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            camara.m_Lens.FieldOfView = Aim;
            anim.SetBool("Aiming", true);
            anim.SetBool("Running", false);
        }
        else if (Input.GetButton("Fire3"))
        {
            camara.m_Lens.FieldOfView = normalView;
            anim.SetBool("Running", true);
            anim.SetBool("Aiming", false);
        }
        else
        {
            camara.m_Lens.FieldOfView = normalView;
            anim.SetBool("Running", false);
            anim.SetBool("Aiming", false);
        }
        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
    }
}
