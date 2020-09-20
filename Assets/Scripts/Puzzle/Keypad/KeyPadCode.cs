using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.Events;


public class KeyPadCode : MonoBehaviour
{
    [Range(0, 9)] public int[] CorrectCode;
    //public int Number;

    [Header("Screen")]
    public TextMeshProUGUI Screen;
     public string WaitText;
    public string ErrorText;
    public string CorrectText;

    public UnityEvent CompletedCode;
    public UnityEvent DisableButton;
    public UnityEvent OnCompleteDelay;


    List<int> cod = new List<int>();
    int index = 0;

    private void Start()
    {
        Screen.text = WaitText;
    }

    public void OffScreen()
    {
        cod.Clear();
        index = 0;
    }

    public void cancel()
    {
        cod.Clear();
        index = 0;
        Screen.text = WaitText;
    } //NADA


    private void Check() //Interno
    {
        
        bool correct = true;
        
        for (int i = 0; i < CorrectCode.Length; i++)
        {                
            if (cod[i] != CorrectCode[i])
             {                
                correct = false;
                break;
             }
        }
        if (correct)
        {
            HideCursor();
            CompletedCode.Invoke();
            Invoke("DelayComplete", 0.5f);
            DisableButton.Invoke();
            Screen.text = CorrectText;
            OffScreen();
        }
        else
        {
            AudioManager.Instance.Play("Beep3");
            Screen.text = ErrorText;            
            OffScreen();
        }     
    }

    public void PressButton(int num) //BOTON
    {
        cod.Add(num);
        index++;
        Screen.text = "";
        for (int i = 0; i < index; i++)
        {
            Screen.text += "*";
        }
        if (index == CorrectCode.Length)
        {
            Check();
        }

    }

    void DelayComplete()
    {
        OnCompleteDelay.Invoke();
    }



    //METODOS PARA EL CURSOR
    public void ShowCursor()
    {
        CursorManager.Instance.ShowCursor();
    }
    public void HideCursor()
    {
        CursorManager.Instance.HideCursor();
    }

}
