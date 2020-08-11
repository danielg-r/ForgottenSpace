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
        //text = GetComponentInChildren<TextMeshProUGUI>();
        text.text = "";    
    }

    void LateUpdate()
    {
        if (isInRange && text != null)
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
        if (other.gameObject.CompareTag("Player") && text != null)
        {
            isInRange = true;
            text.text = "'"+interactKey+"' para "+interactAction;
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
