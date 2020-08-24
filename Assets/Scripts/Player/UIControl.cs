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
    [SerializeField] GameObject bars;
    [SerializeField] GameObject bars1;
    [SerializeField] GameObject bars2;
    [SerializeField] GameObject hotBar;

    void Start()
    {
        buttonMenú.SetActive(false);
        buttonReiniciar.SetActive(false);
        label.text = "";
        if(PlayerLife.Instance != null)
        {
            PlayerLife.Instance.onPlayerDied += new PlayerLife.OnPlayerDied(OnPlayerDied);
        }
    }

    void OnPlayerDied()
    {
        bars.SetActive(false);
        bars1.SetActive(false);
        bars2.SetActive(false);
        hotBar.SetActive(false);
        buttonMenú.SetActive(true);
        buttonReiniciar.SetActive(true);
        label.text = "HAS MUERTO";
        ActivatePistol.Instance.Deactivate();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PlayerMovement.Instance.camara.enabled = false;
        PlayerMovement.Instance.enabled = false;
        PlayerMovement.Instance.GetComponent<CapsuleCollider>().enabled = false;
        PlayerCameraController.Instance.enabled = false;
    }
}
