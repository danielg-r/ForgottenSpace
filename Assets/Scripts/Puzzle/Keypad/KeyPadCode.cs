﻿using System.Collections;
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


    List<int> cod = new List<int>();
    int index = 0;

    private void Start()
    {
        Screen.text = WaitText;
    }

    private void OffScreen()
    {
        cod.Clear();
        index = 0;
    }

    public void cancel()
    {
        cod.Clear();
        index = 0;
        Screen.text = WaitText;
    } //BOTON


    public void Check() //BOTON
    {
        if (index == CorrectCode.Length)
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
                CompletedCode.Invoke();
                DisableButton.Invoke();
                Screen.text = CorrectText;
                OffScreen();
            }
            else
            {
                Screen.text = ErrorText;
                OffScreen();
            }
        }
        else
        {
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
    }


}