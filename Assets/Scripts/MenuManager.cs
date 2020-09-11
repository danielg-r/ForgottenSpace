using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject camara1Play;
    public GameObject camara2Players;

    public GameObject canvas1Play;
    public GameObject canvas2Players;
    public GameObject canvasSkins;

    //Timer
    public float timer = 0f;
    public float d = 1.2f;
    public int mode;

    //ESCENA 0 = MENU / ESCENA 1 = JUEGO

    public void Update()
    {        

       timer += Time.deltaTime;

        if (timer >= d)
        {
            switch (mode)
            {
                case 1:
                    canvas2Players.SetActive(true);                    
                    break;
                case 2:
                    canvas1Play.SetActive(true);
                    break;
            }            
        }
    }

    public void OnCreditosClick()
    {
        //SceneManager.LoadScene(0);
    }


    public void OnPlayClick()
    {
        AudioManager.Instance.Play("Click");
        camara1Play.SetActive(false);
        camara2Players.SetActive(true);

        timer = 0f;
        mode = 1;

        canvas1Play.SetActive(false);
    }
    public void OnReturnClick()
    {
        AudioManager.Instance.Play("Click");
        camara1Play.SetActive(true);
        camara2Players.SetActive(false);


        timer = 0f;
        mode = 2;
        
        canvas2Players.SetActive(false);
    }

    public void Onpersonaje1Click()
    {
        AudioManager.Instance.Play("Click");
        PlayerSelect.Instance.CharacterSelected(1);
        this.gameObject.SetActive(false);
        //canvas1Play.SetActive(false);
        //canvasSkins.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void Onpersonaje2Click()
    {
        AudioManager.Instance.Play("Click");
        PlayerSelect.Instance.CharacterSelected(2);
        this.gameObject.SetActive(false);
        //canvas1Play.SetActive(false);
        //canvasSkins.SetActive(true);
        SceneManager.LoadScene(1);
    }

    public void BackPlayerScreen()
    {
        canvasSkins.SetActive(false);
        canvas1Play.SetActive(true);
    }

    public void Exit()
    {
        Application.Quit();
    }


}
