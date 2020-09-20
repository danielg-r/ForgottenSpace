using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseSystem : MonoBehaviour
{
    public bool IsPaused;
    public GameObject PauseMenu;
    public GameObject PauseButton;
    public GameObject InstrucPanel;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (IsPaused)
        {
            PauseMenu.SetActive(true);
            PauseButton.SetActive(false);
            Time.timeScale = 0f;
            CursorManager.Instance.ShowCursor();

        }
        else
        {
            PauseMenu.SetActive(false);
            PauseButton.SetActive(true);
            Time.timeScale = 1f;
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
            if(!IsPaused) CursorManager.Instance.HideCursor();
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }

    public void ActivateInstruc()
    {
        InstrucPanel.SetActive(true);
    }

    public void CloseInstruc()
    {
        InstrucPanel.SetActive(false);
    }



    public void Pause()
    {
        IsPaused = !IsPaused;
        CursorManager.Instance.HideCursor();
    }
}

