using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class CinematicManager : MonoBehaviour
{
    [SerializeField] AudioListener audioListener;

    public void DisablePlayer()
    {
        PlayerMovement.Instance.enabled = false;
        PlayerMovement.Instance.GetComponent<Animator>().enabled = false;
        UIPlayerControl.Instance.enabled = false;
        Inventory.Instance.enabled = false;
        //Time.timeScale = 0f;
    }

    public void EnablePlayer()
    {
        PlayerMovement.Instance.enabled = true;
        PlayerMovement.Instance.GetComponent<Animator>().enabled = true;
        UIPlayerControl.Instance.enabled = true;
        Inventory.Instance.enabled = true;
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
        CursorManager.Instance.ShowCursor();
    }

    public void ShowCursor()
    {
        Cursor.lockState = CursorLockMode.None;
    }

    public void EnableAudioListener()
    {
        AudioListener.volume = 1;
    }

    public void FinalSequenceObjective() {
        ObjectiveManager.Instance.SetPrincipalObjective("Escapa de la estación.");
        ObjectiveManager.Instance.SetCurrentObjective("Ve al segundo piso del hangar para reparar tu nave", true);
    }

    public void HangarObjective() {
        ObjectiveManager.Instance.SetCurrentObjective("Ve a tu nave e instala el motor", true);
    }

}
