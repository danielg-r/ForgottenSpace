using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CinematicManager : MonoBehaviour
{
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
}
