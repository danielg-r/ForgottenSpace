﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIControl : MonoBehaviour
{
    [SerializeField] Text label;

    void Start()
    {
        label.text = "";
        if(PlayerLife.Instance != null)
        {
            PlayerLife.Instance.onPlayerDied += new PlayerLife.OnPlayerDied(OnPlayerDied);
        }
    }

    void OnPlayerDied()
    {
        label.text = "HAS MUERTO";
        ActivatePistol.Instance.Deactivate();
        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;
        GetComponent<PlayerCameraController>().enabled = false;
        GetComponent<PlayerMovement>().enabled = false;
    }
}
