using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance { get; private set; }
    [SerializeField] Player player;
    [SerializeField] Animator anim;
    [SerializeField] CinemachineFreeLook camara;
    [SerializeField] float Aim = 15f, normalView = 40f;
    public bool CanAim;
    public bool Aiming;

    public float stamina = 5f;
    public float maxStamina = 5f;

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
        player = Player.Instance;
        CanAim = true;
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
        else if (Input.GetButton("Fire3") && stamina > 0f)
        {
            camara.m_Lens.FieldOfView = normalView;
            anim.SetBool("Running", true);
            anim.SetBool("Aiming", false);
            stamina -= Time.deltaTime;
            Aiming = false;
        }
        else
        {
            if(stamina < maxStamina)
            {
                stamina += Time.deltaTime;
            }
            
            camara.m_Lens.FieldOfView = normalView;
            anim.SetBool("Running", false);
            anim.SetBool("Aiming", false);
            Aiming = false;
        }

        anim.SetFloat("vertical", Input.GetAxis("Vertical"));
        anim.SetFloat("horizontal", Input.GetAxis("Horizontal"));
    }
}
