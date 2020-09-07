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
    [SerializeField] AvatarMask avatar;
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
        playerMovement.CanAim = false;
        Deactivate();        
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F)) Activate();
    }

    public void Activate()
    {
        avatar.SetHumanoidBodyPartActive(AvatarMaskBodyPart.LeftArm, false);
        avatar.SetHumanoidBodyPartActive(AvatarMaskBodyPart.RightArm, false);
        avatar.SetHumanoidBodyPartActive(AvatarMaskBodyPart.LeftFingers, false);
        avatar.SetHumanoidBodyPartActive(AvatarMaskBodyPart.RightFingers, false);
        Layer.weight = 1f;
        Pistol.SetActive(true);
        playerMovement.CanAim = true;
    }
    public void Deactivate()
    {
        avatar.SetHumanoidBodyPartActive(AvatarMaskBodyPart.LeftArm, true);
        avatar.SetHumanoidBodyPartActive(AvatarMaskBodyPart.RightArm, true);
        avatar.SetHumanoidBodyPartActive(AvatarMaskBodyPart.LeftFingers, true);
        avatar.SetHumanoidBodyPartActive(AvatarMaskBodyPart.RightFingers, true);
        Debug.Log("Desactivando");
        Layer.weight = 0f;
        Pistol.SetActive(false);
        playerMovement.CanAim = false;
    }
}
