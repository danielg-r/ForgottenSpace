using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class ActivatePistol : MonoBehaviour
{
    [SerializeField] Rig Layer;
    [SerializeField] GameObject Pistol;
    PlayerMovement playerMovement;

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
