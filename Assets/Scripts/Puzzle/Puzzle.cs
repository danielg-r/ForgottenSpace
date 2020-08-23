using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Puzzle : MonoBehaviour
{

    public GameObject[] Levers;
    [Range(0, 2)] public int[] code;    
    int[] internalCode; 
    //-----
    public UnityEvent OnInteract;

    private void Start()
    {
        internalCode = new int[code.Length];
    }

    void CorrectCode()
    {
        OnInteract.Invoke();
    }

    public void ReceberSignal(GameObject go, int _state)
    {
        for(int i = 0; i < Levers.Length;i++)
        {
            if(go == Levers[i])
            {
                internalCode[i] = _state;
                break;
            }
        }
        verificar();
    }

    void verificar()
    {
        bool correct = true;

        for (int i = 0; i < code.Length; i++)
        {
            if (internalCode[i] != code[i])
            {
                correct = false;
                break;
            }
        }

        if (correct)
        {
            foreach(GameObject a in Levers)
            {
                a.GetComponent<Levers>().puedegirar = false;
            }
            CorrectCode();
        }
    }

}
