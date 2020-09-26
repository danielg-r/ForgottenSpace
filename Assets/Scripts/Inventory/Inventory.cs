using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    //private static Inventory Instance
    [SerializeField] Image inventory;
    //[SerializeField] GameObject invCamera; ==> Dejar aquí en caso de querer hacer transición más tarde :)
    bool isOpen;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) &&!UIDeathControl.Instance.IsPaused)
        {
            isOpen = !isOpen;
            OpenInventory();
        }
    }
    void OpenInventory()
    {
        if (isOpen == true && !UIDeathControl.Instance.IsPaused)
        {
            UIDeathControl.Instance.enabled = false;
            GetComponent<PlayerCameraController>().enabled = false;            
            inventory.rectTransform.localScale = Vector3.one;
            GetComponent<PlayerMovement>().enabled = false;
            FreezeGame();
        }
        else
        {
            UIDeathControl.Instance.enabled = true;
            GetComponent<PlayerCameraController>().enabled = true;
            inventory.rectTransform.localScale = Vector3.zero;            
            GetComponent<PlayerMovement>().enabled = true;
            FreezeGame();
        }
    }

    void FreezeGame()
    {
        if (isOpen == true && !UIDeathControl.Instance.IsPaused)
        {
            Time.timeScale = 0f;
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } 
        else if (!UIDeathControl.Instance.IsPaused)
        {
            Time.timeScale = 1f;
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        } 
    }
}
