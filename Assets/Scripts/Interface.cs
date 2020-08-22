using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public GameObject camara1Play;
    public GameObject camara2Personajes;
    public GameObject camara3Options;

    public GameObject canvas1Play;
    public GameObject canvas2Personajes;
    public GameObject canvas3Options;

    //prefabs de los personajes van aquí
    public GameObject personaje1;
    public GameObject personaje2;
    public GameObject personaje3;

    //Sitio de Spawn de los personajes.
    public Transform spawnPoint;


      //Timer
      public float timer = 0f;
      public float d = 1.2f;
      public int mode;

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
        //GameObject personaje1 = Instantiate(personaje1, spawnPoint.position, spawnPoint.rotation);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Onpersonaje2Click()
    {        
        //GameObject personaje2 = Instantiate(personaje2, spawnPoint.position, spawnPoint.rotation);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Onpersonaje3Click()
    {        
        //GameObject personaj3 = Instantiate(personaje3, spawnPoint.position, spawnPoint.rotation);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void OnDeathClick() //AQUI ES QUE ME MORI XD
    {
        SceneManager.LoadScene(0); //ESCENA 0 = MENU
    }

    
}
