using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InterPuzzle : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent OnInteract;
    //[SerializeField] string interactAction;
    [SerializeField] TextMeshProUGUI text;
    Color green = new Color(0f, 255f, 0f);

    void Awake()
    {
        //text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = ""; 
        text.color = green;   
    }

    void LateUpdate()
    {
        if (isInRange && text != null)
        {
            if (Input.GetKeyDown(interactKey))
            {
                OnInteract.Invoke();               
                
            }
        }        
    }

    void OnTriggerEnter(Collider other)
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
