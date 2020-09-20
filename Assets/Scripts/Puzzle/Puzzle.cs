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
    public UnityEvent OnPuzzleCompleted;

    private void Start()
    {
        internalCode = new int[code.Length];
    }

    void CorrectCode()
    {
        OnPuzzleCompleted.Invoke();
        this.enabled = false;
        foreach(GameObject g in Levers)
        {
            g.SetActive(false);
        }
        AudioManager.Instance.Play("PuzzleSolved");
        PlayerCameraController.Instance.canvasText.text = "";

    }

    public void ReceiveSignal(GameObject go, int _state)
    {
        for(int i = 0; i < Levers.Length;i++)
        {
            if(go == Levers[i])
            {
                internalCode[i] = _state;
                break;
            }
        }
        Check();
    }

    void Check()
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
                a.GetComponent<Levers>().CanTurn = false;
            }
            CorrectCode();
        }
    }

}
