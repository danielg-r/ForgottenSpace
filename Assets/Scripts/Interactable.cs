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
    [SerializeField] string interactAction;
    [SerializeField] TextMeshProUGUI text;

    void Awake()
    {
        //text = GameObject.Find("InteractionText").GetComponent<TextMeshProUGUI>();
        text.text = "";    
    }

    void LateUpdate()
    {
        if (isInRange)
        {
            if (Input.GetKeyDown(interactKey))
            {
                OnInteract.Invoke();
                text.text = "";
            }
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = true;
            text.text = "Presiona '"+interactKey+"' para "+interactAction;
        }        
    }
    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isInRange = false;
            text.text = "";
        }        
    }
}
