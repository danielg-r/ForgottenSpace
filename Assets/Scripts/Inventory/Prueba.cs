using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Prueba : MonoBehaviour
{
    public AudioMixer mixer;

    void Update()
    {
       if(Input.GetKeyDown(KeyCode.H))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        } 
    }
    public void ChangeVolume(float vol)
    {
        mixer.SetFloat("Volume", vol);
    }
}
