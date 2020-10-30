using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{

    private static Inventory instance;

    [SerializeField] Image inventory;
    //[SerializeField] GameObject invCamera; ==> Dejar aquí en caso de querer hacer transición más tarde :)
    public bool isOpen;
    //public bool Opened = false;

    public static Inventory Instance { get => instance; }

    void Awake()
    {
        if (Instance == null) instance = this;
    }

    void Update()
    {
        if (Input.GetButtonDown("Inventory"))
        {
            if ( (UIPlayerControl.Instance.IsPaused == false) && (UIPlayerControl.Instance.isActiveAndEnabled == true) )
            {
                isOpen = !isOpen;
                OpenInventory();                
            }
        }
    }

    void OpenInventory()
    {
        
        if (isOpen == true)
        {
            GetComponent<PlayerCameraController>().enabled = false;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            inventory.rectTransform.localScale = Vector3.one;
            GetComponent<PlayerMovement>().enabled = false;
            FreezeGame();
            //Opened = true;
            //invCamera.SetActive(true); ==> Dejar aquí en caso de querer hacer transición más tarde :)
        }
        else
        {
            GetComponent<PlayerCameraController>().enabled = true;
            //invCamera.SetActive(false); ==> Dejar aquí en caso de querer hacer transición más tarde :)
            inventory.rectTransform.localScale = Vector3.zero;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            GetComponent<PlayerMovement>().enabled = true;
            //Opened = false;
            //Invoke("CCDelay", 2); ==> Dejar aquí en caso de querer hacer transición más tarde :)
            FreezeGame();
        }

        
    }

    void FreezeGame()
    {
        if (isOpen == true) Time.timeScale = 0f;
        else Time.timeScale = 1f;
    }

    void CCDelay()
    {
        GetComponent<PlayerCameraController>().enabled = true;
    }
}
