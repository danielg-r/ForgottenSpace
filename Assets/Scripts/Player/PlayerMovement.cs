using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }
    [SerializeField] Animator anim;
    public CinemachineFreeLook camara;
    [SerializeField] float Aim = 15f, normalView = 40f;
    [SerializeField] int AmountStamina = 1;
    public bool CanAim;
    public bool Aiming;
    public bool CanRun;
    [SerializeField] StaminaBar Bar;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Start()
    {
        CanAim = true;
        CanRun = true;
    }
    void Update()
    {
        if (Input.GetMouseButton(1) && CanAim)
        {
            camara.m_Lens.FieldOfView = Aim;
            anim.SetBool("Aiming", true);
            anim.SetBool("Running", false);
            Aiming = true;
        }
        else if (Input.GetButton("Fire3") && CanRun)
        {
            camara.m_Lens.FieldOfView = normalView;
            anim.SetBool("Running", true);
            anim.SetBool("Aiming", false);
            Aiming = false;
            Bar.UseStamina(AmountStamina);
        }
        else
        {
            camara.m_Lens.FieldOfView = normalView;
            anim.SetBool("Running", false);
            anim.SetBool("Aiming", false);
            Aiming = false;
        }

        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
    }

    public void NoStamina()
    {
        CanRun = false;
    }
    public void HasStamina()
    {
        CanRun = true;
    }
}
