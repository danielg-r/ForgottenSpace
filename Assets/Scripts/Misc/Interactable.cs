using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Interactable : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent OnInteract;
    //[SerializeField] string interactAction;
    TextMeshProUGUI text;
    Color green = new Color(0f, 255f, 0f);


    void Start()
    {
        text = PlayerCameraController.Instance.canvasText;
        text.text = ""; 
        text.color = green;
    }    

    void Update()
    {
        if (isInRange && text != null)
        {
            if (Input.GetKeyDown(interactKey) || Input.GetButtonDown("Interactable"))
            {
                OnInteract.Invoke();
                isInRange = false;                
                text.text = "";
            }
        }        
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && text != null)
        {
            isInRange = true;
            text.text = "["+interactKey+"]";
        }        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && text != null)
        {
            isInRange = false;
            text.text = "";
        }        
    }
}
