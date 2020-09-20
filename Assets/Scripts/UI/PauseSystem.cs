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

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Pause();
            if(!IsPaused) CursorManager.Instance.HideCursor();
        }
    }

    public void Exit()
    {
        Time.timeScale = 1f;        
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
            CursorManager.Instance.HideCursor();
        }
    }
}

