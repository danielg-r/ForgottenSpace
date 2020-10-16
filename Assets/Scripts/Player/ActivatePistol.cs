using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActivatePistol : MonoBehaviour
{
    public static ActivatePistol Instance { get; private set; }
    [SerializeField] Rig Layer;
    [SerializeField] GameObject Pistol;
    [SerializeField] GameObject Pistolbar;

    PlayerMovement playerMovement;
    Animator animator;

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

    void Start()
    {
        playerMovement = PlayerMovement.Instance;
        animator = GetComponent<Animator>();
        Deactivate();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) Activate();
    }

    public void Activate()
    {
        if (GetCharacter.Instance.IsMale)
        {
            animator.runtimeAnimatorController = Resources.Load("PlayerMask") as RuntimeAnimatorController;
        }
        else animator.runtimeAnimatorController = Resources.Load("PlayerWomanMask") as RuntimeAnimatorController;
        Layer.weight = 1f;
        Pistol.SetActive(true);
        Pistolbar.SetActive(true);
        playerMovement.CanAim = true;
    }
    public void Deactivate()
    {
        Layer.weight = 0f;
        Pistol.SetActive(false);
        playerMovement.CanAim = false;
    }
}
