using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
}
