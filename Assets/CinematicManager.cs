﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CinematicManager : MonoBehaviour
{

    public UnityEvent OnOpenShop;
    public UnityEvent OnOpenCraft;

    public UnityEvent OnCloseShop;
    public UnityEvent OnCloseraft;

    public void DisablePlayer()
    {
        PlayerMovement.Instance.enabled = false;
        //Time.timeScale = 0f;
    }

    public void EnablePlayer()
    {
        PlayerMovement.Instance.enabled = true;
        //Time.timeScale = 1f;
    }

    public void DisableAllEnemies()
    {
        EnemyController[] robots = FindObjectsOfType<EnemyController>();
        DroneController[] patrolDrones = FindObjectsOfType<DroneController>();
        DroneAttack[] attackDrones = FindObjectsOfType<DroneAttack>();

        foreach(EnemyController i in robots) i.enabled = false;
        foreach(DroneController i in patrolDrones) i.enabled = false;
        foreach(DroneAttack i in attackDrones) i.enabled = false;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void ActiveShopCinematic()
    {
        OnOpenShop.Invoke();
    }
    public void ActiveCraftCinematic()
    {
        OnOpenCraft.Invoke();
    }

    public void DisableCraftCinematic()
    {
        OnCloseraft.Invoke();
    }
    public void DisableShopCinematic()
    {
        OnCloseShop.Invoke();
    }

}
