using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    [SerializeField] GameObject inventory;
    //[SerializeField] GameObject invCamera; ==> Dejar aquí en caso de querer hacer transición más tarde :)
    //[SerializeField] GameObject playerCamera;

    //private int freeSlotAmount;
    //private GameObject[] slots;

    private AudioManager audio;


    bool isOpen;

    void Awake()
    {
        //if (Instance == null)
        //{
        //    Instance = this;
        //}
        //else
        //{
        //    Destroy(gameObject);
        //}

        //freeSlotAmount = inventory.transform.childCount;
        //DetectSlots();
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            isOpen = !isOpen;
            OpenInventory();
            //audio.Play("Test");
        }
    }

    void LateUpdate()
    {
        //FreezeGame();
    }

    //public void OnTriggerEnter(Collider other)
    //{
        
    //}

    //public void AddItem(GameObject item)
    //{

    //}


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
            FreezeGame();
            //invCamera.SetActive(true); ==> Dejar aquí en caso de querer hacer transición más tarde :)
            //Invoke("ActivateCamera", 1);

        }
        else
        {
            GetComponent<PlayerCameraController>().enabled = true;
            // playerCamera.SetActive(true);
            //invCamera.SetActive(false); ==> Dejar aquí en caso de querer hacer transición más tarde :)
            inventory.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            //Time.timeScale = 1f;
            GetComponent<PlayerMovement>().enabled = true;
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

    void ActivateCamera()
    {
        
    }

    //void DetectSlots()
    //{

    //}
}
