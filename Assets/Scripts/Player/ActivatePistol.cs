using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActivatePistol : MonoBehaviour
{
    public static ActivatePistol Instance { get; private set; }
    [SerializeField] Rig Layer;
    [SerializeField] GameObject Pistol;
    PlayerMovement playerMovement;

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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) Activate();
    }

    private void Start()
    {
        playerMovement = PlayerMovement.Instance;
    }

    public void Activate()
    {
        Layer.weight = 1f;
        Pistol.SetActive(true);
        playerMovement.CanAim = true;
    }
    public void Deactivate()
    {
        Layer.weight = 0f;
        Pistol.SetActive(false);
        playerMovement.CanAim = false;
    }
}
