using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonsManager : MonoBehaviour
{
    public GameObject camara1Play;
    public GameObject camara2Personajes;
    public GameObject camara3Options;

    public GameObject canvas1Play;
    public GameObject canvas2Personajes;
    public GameObject canvas3Options;

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
                    canvas2Personajes.SetActive(true);                    
                    break;
                case 2:
                    canvas1Play.SetActive(true);
                    break;
                case 3:
                    canvas3Options.SetActive(true);
                    break;
                default:                    
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
        camara2Personajes.SetActive(true);
        camara3Options.SetActive(false);

        timer = 0f;
        mode = 1;

        canvas1Play.SetActive(false);
        canvas3Options.SetActive(false);
    }
    public void OnReturnClick()
    {
        AudioManager.Instance.Play("Click");
        camara1Play.SetActive(true);
        camara2Personajes.SetActive(false);
        camara3Options.SetActive(false);


        timer = 0f;
        mode = 2;
        
        canvas2Personajes.SetActive(false);
        canvas3Options.SetActive(false);
    }

    public void OnOptionsClick()
    {
        AudioManager.Instance.Play("Click");
        camara1Play.SetActive(false);
        camara2Personajes.SetActive(false);
        camara3Options.SetActive(true);

        timer = 0f;
        mode = 3;

        canvas1Play.SetActive(false);
        canvas2Personajes.SetActive(false);        
    }

    public void Onpersonaje1Click()
    {
        AudioManager.Instance.Play("Click");
        Select.Instance.CharacterSelected(1);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Onpersonaje2Click()
    {
        AudioManager.Instance.Play("Click");
        Select.Instance.CharacterSelected(2);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void OnMenuClick()
    {
        SceneManager.LoadScene(0);
    }

    public void Exit()
    {
        Application.Quit();
    }


}
