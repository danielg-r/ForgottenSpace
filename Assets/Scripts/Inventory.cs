using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    [SerializeField] GameObject invCamera;
    //[SerializeField] GameObject playerCamera;


    bool isOpen;

    void Awake()
    {

    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            OpenInventory();
        }
    }

    void LateUpdate()
    {
        //FreezeGame();
    }

    void OpenInventory()
    {
        if (isOpen == true)
        {
            GetComponent<PlayerCameraController>().enabled = false;
            // playerCamera.SetActive(false);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            //Time.timeScale = 0f;
            inventory.SetActive(true);
            GetComponent<PlayerMovement>().enabled = false;
            invCamera.SetActive(true);
            //Invoke("ActivateCamera", 1);
            
        }
        else
        {
            // playerCamera.SetActive(true);
            invCamera.SetActive(false);
            inventory.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            //Time.timeScale = 1f;
            GetComponent<PlayerMovement>().enabled = true;
            Invoke("CCDelay", 2);

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

    void ActivateCamera()
    {
        
    }
}
