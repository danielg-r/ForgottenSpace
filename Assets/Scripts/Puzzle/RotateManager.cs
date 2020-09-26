using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotateManager : MonoBehaviour
{

    [SerializeField]
    public Transform[] pictures;

    [Header("Timer")]
    public AirSystem Timer;

    [SerializeField] private GameObject WinUI;

    public static bool youWin;

    [Header("Eventos")]
    public UnityEvent OnPuzzleCompleted;
    public UnityEvent OnCompleteDelay;

    private void Start()
    {
        Timer.startTimer(); //FUNCION DE PRUEBA
        youWin = false;
    }


    public void QuestionYouWin()
    {
        if (pictures[0].rotation.z == 0 &&
           pictures[1].rotation.z == 0 &&
           pictures[2].rotation.z == 0 &&
           pictures[3].rotation.z == 0 &&
           pictures[4].rotation.z == 0 &&
           pictures[5].rotation.z == 0 &&
           pictures[6].rotation.z == 0 &&
           pictures[7].rotation.z == 0 &&
           pictures[8].rotation.z == 0)
        {
            youWin = true;
            Timer.StopTimer();
            WinUI.SetActive(true);
            OnPuzzleCompleted.Invoke();
            Invoke("DelayComplete", 1.5f);

        }
    }

    public void NewGame()
    {
        pictures[0].rotation = Quaternion.Euler(0f, 0f, 180f);
        pictures[1].rotation = Quaternion.Euler(0f, 0f, 90f);
        pictures[2].rotation = Quaternion.Euler(0f, 0f, 270f);
        pictures[3].rotation = Quaternion.Euler(0f, 0f, 90f);
        pictures[4].rotation = Quaternion.Euler(0f, 0f, 90f);
        pictures[5].rotation = Quaternion.Euler(0f, 0f, -90f);
        pictures[6].rotation = Quaternion.Euler(0f, 0f, 90f);
        pictures[7].rotation = Quaternion.Euler(0f, 0f, 180f);
        pictures[8].rotation = Quaternion.Euler(0f, 0f, 0f);
        Timer.startTimer();

    }

    void DelayComplete()
    {
        OnCompleteDelay.Invoke();
    }


}
