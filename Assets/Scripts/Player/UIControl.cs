using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] Text label;

    void Start()
    {
        label.text = "";
        if(PlayerLife.Instance != null)
        {
            PlayerLife.Instance.onPlayerDied += new PlayerLife.OnPlayerDied(OnPlayerDied);
        }
    }

    void OnPlayerDied()
    {
        label.text = "HAS MUERTO";
        ActivatePistol.Instance.Deactivate();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PlayerMovement.Instance.camara.enabled = false;
        PlayerMovement.Instance.enabled = false;
        PlayerCameraController.Instance.enabled = false;
    }
}
