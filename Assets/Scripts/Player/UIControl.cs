using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIControl : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] GameObject buttonMenú;
    [SerializeField] GameObject buttonReiniciar;

    void Start()
    {
        buttonMenú.SetActive(false);
        buttonMenú.SetActive(false);
        label.text = "";
        if(PlayerLife.Instance != null)
        {
            PlayerLife.Instance.onPlayerDied += new PlayerLife.OnPlayerDied(OnPlayerDied);
        }
    }

    void OnPlayerDied()
    {
        buttonMenú.SetActive(true);
        buttonMenú.SetActive(true);
        label.text = "HAS MUERTO";
        ActivatePistol.Instance.Deactivate();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PlayerMovement.Instance.camara.enabled = false;
        PlayerMovement.Instance.enabled = false;
        PlayerCameraController.Instance.enabled = false;
    }
}
