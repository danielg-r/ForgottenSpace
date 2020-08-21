using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class InteraCraft : MonoBehaviour
{
    public bool isInRange;
    public KeyCode interactKey;
    public UnityEvent OnInteract;
    [SerializeField] TextMeshProUGUI text;
    [SerializeField] CraftSystem craftSystem;
    Color green = new Color(0f, 255f, 0f);    



    void Awake()
    {        
        text.text = ""; 
        text.color = green;
        
    }

    void LateUpdate()
    {
        if (isInRange && text != null)
        {
            if (Input.GetKeyDown(interactKey) && craftSystem.CanCraft)
            {
                OnInteract.Invoke();                
                text.text = "Item Crafteado";
            }
            if (Input.GetKeyDown(interactKey) && !craftSystem.CanCraft)
            {
                OnInteract.Invoke();
                text.text = "No Piezas";
            }
        }        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && text != null)
        {
            isInRange = true;
            text.text = "["+interactKey+"] -- "+craftSystem.pieces+"/"+craftSystem.necessaryPieces;

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
