using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Reflection.Emit;
using DG.Tweening;

public class UIDeathControl : MonoBehaviour
{
    private static UIDeathControl instance;

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

    [Header("Status Text")]
    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] DOTweenAnimation scrambleTween;
    public bool showingText;

    public static UIDeathControl Instance { get => instance; }

    void Awake()
    {
        if (Instance == null) instance = this;
    }

    void Start()
    {
        ContinueButton.SetActive(true);
        InstruButton.SetActive(true);
        label.text = "";
        if(PlayerLife.Instance != null)
        {
            PlayerLife.Instance.onPlayerDied += OnPlayerDied;
        }
    }

    void OnPlayerDied()
    {
        Debug.Log("Player muerto");
        bars.SetActive(false);
        bars1.SetActive(false);
        bars2.SetActive(false);
        hotBar.SetActive(false);
        ContinueButton.SetActive(false);
        InstruButton.SetActive(false);
        PauseMenu.SetActive(true);

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
        if (Input.GetButtonDown("Pause") && ( IsAlive == true ))
        {
            if(Inventory.Instance.isOpen == false)
            {
                label.text = "PAUSA";
                Pause();                
                if (!IsPaused) CursorManager.Instance.HideCursor();

            }
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

    public void SetStatusText(string status)
    {
        statusText.text = status;
        showingText = true;
        statusText.gameObject.SetActive(true);
        statusText.gameObject.GetComponent<DOTweenAnimation>().DOPlay(); 
        Invoke("DisableStatusText", 5f);
    }

    public void DisableStatusText()
    {
        statusText.gameObject.SetActive(false);      
        statusText.gameObject.GetComponent<DOTweenAnimation>().DORewind();
        showingText = false;
        statusText.text = "";
    }



}
