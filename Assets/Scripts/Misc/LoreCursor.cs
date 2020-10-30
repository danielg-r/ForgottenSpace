using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoreCursor : MonoBehaviour
{
    public void ShowCursor()
    {
         Time.timeScale = 0f;
         Cursor.lockState = CursorLockMode.None;
         Cursor.visible = true;       
    }

    public void HideCursor()
    {
        if (Inventory.Instance.isOpen == false)
        {
            Time.timeScale = 1f;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else { Inventory.Instance.canClose = true; }
    }
}
