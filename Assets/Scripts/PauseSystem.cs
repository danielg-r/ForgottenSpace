using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSystem : MonoBehaviour
{
    public bool IsPaused;
    public GameObject PauseMenu;

    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (IsPaused)
        {
            //PauseMenu.SetActive(true);
            Time.timeScale = 0f;
        }
        else
        {
            //PauseMenu.SetActive(false);
            Time.timeScale = 1f;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            IsPaused = !IsPaused;
        }
    }

    public void Pause()
    {
        IsPaused = !IsPaused;
    }
    public void Exit()
    {
        Application.Quit();
    }
}

