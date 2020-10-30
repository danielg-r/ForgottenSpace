using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;
using System.Reflection.Emit;
using DG.Tweening;
using JetBrains.Annotations;
using Michsky.UI.ModernUIPack;
using UnityEngine.Events;

public class UIPlayerControl : MonoBehaviour
{
    private static UIPlayerControl instance;

    [Header("Death")]
    [SerializeField] TextMeshProUGUI label;
    [SerializeField] GameObject ContinueButton;
    [SerializeField] GameObject InstruButton;
    [SerializeField] GameObject respawnButton;

    [Header("Bars")]
    [SerializeField] GameObject bars;
    [SerializeField] GameObject bars1;
    [SerializeField] GameObject bars2;
    [SerializeField] GameObject hotBar;

    [Header("Pausa")]
    public bool IsPaused;
    public GameObject PauseMenu;
    private bool IsAlive = true;

    [Header("Status Text")]
    [SerializeField] TextMeshProUGUI statusText;
    [SerializeField] DOTweenAnimation scrambleTween;
    public bool showingText;

    public ModalWindowManager Instrucciones;

    public static UIPlayerControl Instance { get => instance; }

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
            PlayerLife.Instance.onPlayerRespawned += OnPlayerRespawned;
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
        respawnButton.SetActive(true);
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

    void OnPlayerRespawned() {
        Debug.Log("Respawning... ");
        PauseMenu.SetActive(false);
        bars.SetActive(true);
        bars1.SetActive(true);
        if (CraftSystem.Instance.ICraftPistol) {
            bars2.SetActive(true);
            ActivatePistol.Instance.Activate();
        }
        if (ShopManager.Instance.hasVisitedShop) hotBar.SetActive(true);        
        ContinueButton.SetActive(true);
        InstruButton.SetActive(true);
        respawnButton.SetActive(false);
        label.text = "";
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Confined;
        PlayerMovement.Instance.camara.enabled = true;
        PlayerMovement.Instance.enabled = true;
        PlayerMovement.Instance.GetComponent<CapsuleCollider>().enabled = true;
        PlayerCameraController.Instance.enabled = true;
        IsAlive = true;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Pause") && ( IsAlive == true ))
        {
            Instrucciones.CloseWindow();
            if (Inventory.Instance.isOpen == false)
            {
                label.text = "PAUSA";
                Pause();                
                if (!IsPaused) CursorManager.Instance.HideCursor();
            }
        }
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
