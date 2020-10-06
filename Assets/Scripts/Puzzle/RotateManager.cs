using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RotateManager : MonoBehaviour
{

    [SerializeField]
    public Transform[] pictures;

    [SerializeField] private GameObject WinUI;

    public static bool youWin;

    [Header("Eventos")]
    public UnityEvent OnPuzzleCompleted;
    public UnityEvent OnCompleteDelay;

    private void Start()
    {
        youWin = false;
    }


    public void QuestionYouWin()
    {
        Debug.Log("Question Win");
        Debug.Log(pictures[0].rotation.z);
        Debug.Log(pictures[1].rotation.z);
        Debug.Log(pictures[2].rotation.z);
        Debug.Log(pictures[3].rotation.z);
        Debug.Log(pictures[4].rotation.z);
        Debug.Log(pictures[5].rotation.z);
        Debug.Log(pictures[6].rotation.z);
        Debug.Log(pictures[7].rotation.z);
        Debug.Log(pictures[8].rotation.z);

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
            Debug.Log("Win");

            youWin = true;
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
        youWin = false;
    }

    void DelayComplete()
    {
        OnCompleteDelay.Invoke();
    }


}
