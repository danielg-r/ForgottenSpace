using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Reflection.Emit;

public class UIDeathControl : MonoBehaviour
{
    [Header("Death")]
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] GameObject ContinueButton;
    [SerializeField] GameObject InstruButton;

    [Header("Bars")]
    [SerializeField] GameObject bars;
    [SerializeField] GameObject bars1;
    [SerializeField] GameObject bars2;
    [SerializeField] GameObject hotBar;

    [Header("Pausa")]
    public bool IsPaused;
    public GameObject PauseMenu;
    public GameObject InstrucPanel;
    private bool IsAlive = true;

    void Start()
    {
        ContinueButton.SetActive(true);
        InstruButton.SetActive(true);
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
        ContinueButton.SetActive(false);
        InstruButton.SetActive(false);

        label.text = "HAS MUERTO";
        ActivatePistol.Instance.Deactivate();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        PlayerMovement.Instance.camara.enabled = false;
        PlayerMovement.Instance.enabled = false;
        PlayerMovement.Instance.GetComponent<CapsuleCollider>().enabled = false;
        PlayerCameraController.Instance.enabled = false;
        IsAlive = false;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && IsAlive == true)
        {
            label.text = "PAUSA";
            Pause();
            if (!IsPaused) CursorManager.Instance.HideCursor();
        }
    }

    public void ActivateInstruc()
    {
        InstrucPanel.SetActive(true);
    }

    public void CloseInstruc()
    {
        InstrucPanel.SetActive(false);
    }

    public void Pause()
    {
        IsPaused = !IsPaused;
        if (IsPaused)
        {
            PauseMenu.SetActive(true);
            Time.timeScale = 0f;
            CursorManager.Instance.ShowCursor();
        }
        else
        {
            PauseMenu.SetActive(false);
            Time.timeScale = 1f;
            CursorManager.Instance.HideCursor();
        }
    }


    public void OnMenuClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }
}
