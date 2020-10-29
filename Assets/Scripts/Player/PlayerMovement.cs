using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }
    [SerializeField] Animator anim;
    [HideInInspector] public CinemachineFreeLook camara;
    float Aim = 40f, normalView = 70f;
    [SerializeField] float AmountStamina = 1;
    [HideInInspector] public bool CanAim;
    [HideInInspector] public bool Aiming;
    bool CanRun;
    [SerializeField] StaminaBar Bar;
    float vertical;
    float horizontal;

    bool isAxisInUse;

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
        CanRun = true;
    }
    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if (Input.GetAxisRaw("Aim") == 0) isAxisInUse = false;
        if (Input.GetAxisRaw("Aim") >= 0.5f || Input.GetButton("Aim"))
        {
            if (!isAxisInUse && CanAim)
            {
                camara.m_Lens.FieldOfView = Aim;
                anim.SetBool("Aiming", true);
                anim.SetBool("Running", false);
                Aiming = true;
                isAxisInUse = true;
            }
        }
        else if (Input.GetButton("Run") && CanRun)
        {
            camara.m_Lens.FieldOfView = normalView;
            anim.SetBool("Running", true);
            anim.SetBool("Aiming", false);
            Aiming = false;
            if (vertical > 0.7 || vertical < -0.7 || horizontal > 0.7 || horizontal < -0.7)
            {
                Bar.UseStamina(AmountStamina);
            }
        }
        else
        {
            camara.m_Lens.FieldOfView = normalView;
            anim.SetBool("Running", false);
            anim.SetBool("Aiming", false);
            Aiming = false;
        }

        anim.SetFloat("vertical", vertical);
        anim.SetFloat("horizontal", horizontal);
    }

    public void NoStamina()
    {
        CanRun = false;
    }
    public void HasStamina()
    {
        CanRun = true;
    }

    public void Walk1()
    {
        AudioManager.Instance.Play("Walk1");
    }
    public void Walk2()
    {
        AudioManager.Instance.Play("Walk2");
    }
}
