using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    [SerializeField] GameObject timeline; 
    void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
       {
           timeline.SetActive(true);
       } 
    }
}
