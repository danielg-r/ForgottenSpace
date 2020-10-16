using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

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

    public object Break { get; private set; }

    private void Start()
    {
        youWin = false;
        completed = false;
    }

    public bool completed = false;
    public void QuestionYouWin()
    {
        
        for(int i = 0; i <= pictures.Length-1; i++)
        {
            if (pictures[i].rotation.z != 0) 
            { completed = false; break; }
            completed = true;
        }

        if (completed == true)
        {
            Debug.Log("Win");

            youWin = true;
            //WinUI.SetActive(true);
            OnPuzzleCompleted.Invoke();
            HazardManager.Instance.StopHazards();
            Invoke("DelayComplete", 1.5f);
        }
        else
        {
            Debug.Log("No Gano");
        }

    }

    public void NewGame()
    {
        for (int i = 0; i <= pictures.Length-1; i++)
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
        youWin = false;
    }

    void DelayComplete()
    {
        OnCompleteDelay.Invoke();
    }


}
