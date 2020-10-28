using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class RotateManager : MonoBehaviour
{
    [SerializeField]
    public Transform[] pictures;
    [SerializeField] private GameObject WinUI;
    public Interactable interactable;
    public GameObject ps;
    public GameObject ps2;

    public static bool youWin;

    [Header("Eventos")]
    public UnityEvent OnPuzzleCompleted;
    public UnityEvent OnCompleteDelay;

    [Header("Imagenes Recortadas")]
    public Sprite[] Imagenes0;
    public Sprite[] Imagenes1;
    public Sprite[] Imagenes2;
    public Sprite[] Imagenes3;
    public Sprite[] Imagenes4;
    public Sprite[] Imagenes5;
    public Sprite[] Imagenes6;
    public Sprite[] Imagenes7;
    public Sprite[] Imagenes8;

    [Header("Imagenes - Completas")]
    public Sprite[] ReferenceImage;
    public Image ReferenceObjectImage;

    [Header("Imagenes - Botones")]
    public Image Image0;
    public Image Image1;
    public Image Image2;
    public Image Image3;
    public Image Image4;
    public Image Image5;
    public Image Image6;
    public Image Image7;
    public Image Image8;


    public object Break { get; private set; }

    private void Start()
    {
        youWin = false;
        completed = false;
    }

    public bool completed = false;
    public void QuestionYouWin()
    {
        
        for(int i = 0; i < pictures.Length; i++)
        {
            if (pictures[i].rotation.z != 0) 
            { completed = false; break; }
            completed = true;
        }

        if (completed == true)
        {
            youWin = true;
            //WinUI.SetActive(true);
            OnPuzzleCompleted.Invoke();
            HazardManager.Instance.StopHazards();
            Invoke("DelayComplete", 1.5f);
        }
        else
        {
        }

    }

    public void NewGame()
    {
        youWin = false;
        ChangeImage();
        completed = false;

        for (int i = 0; i < pictures.Length; i++)
        {
            float value;
            switch (Random.Range(1, 3))
            {
                case 1:
                    value = 90f;
                    break;
                case 2:
                    value = 270f;
                    break;
                default:
                    value = 0f;
                    break;
            }
            pictures[i].rotation = Quaternion.Euler(0f, 0f, value);
            
        }

    }

    void ChangeImage()
    {
        int i = Random.Range(0, Imagenes0.Length);

        Image0.sprite = Imagenes0[i];
        Image1.sprite = Imagenes1[i];
        Image2.sprite = Imagenes2[i];
        Image3.sprite = Imagenes3[i];
        Image4.sprite = Imagenes4[i];
        Image5.sprite = Imagenes5[i];
        Image6.sprite = Imagenes6[i];
        Image7.sprite = Imagenes7[i];
        Image8.sprite = Imagenes8[i];

        ReferenceObjectImage.sprite = ReferenceImage[i];
    }


    void DelayComplete()
    {
        OnCompleteDelay.Invoke();
    }


}
