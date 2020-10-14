using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateScript : MonoBehaviour
{
    RotateManager Manager;

    void Start() {
        Manager = GetComponentInParent<RotateManager>();
    }

    public void OnMouseDown()
    {
        if(!RotateManager.youWin)
        {
            transform.Rotate(0f, 0f, 90f);
            Manager.QuestionYouWin();
        }
    }


}
