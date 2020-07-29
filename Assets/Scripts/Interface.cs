using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interface : MonoBehaviour
{
    public GameObject play;
    public GameObject menu;
    public GameObject options;

    //prefabs de los personajes van aquí
    public GameObject personaje1;
    public GameObject personaje2;
    public GameObject personaje3;

    //Sitio de Spawn de los personajes.
    public Transform spawnPoint;
    public void OnCreditsClick()
    {
        SceneManager.LoadScene(0);
    }

    public void OnPlayClick()
    {
        play.SetActive(true);
        menu.SetActive(false);
    }
    public void OnReturnClick()
    {
        play.SetActive(false);
        menu.SetActive(false);
    }

    public void OnOptionsClick()
    {        
        options.SetActive(true);
        play.SetActive(false);
    }

    public void Onpersonaje1Click()
    {        
        GameObject vigiaClone = Instantiate(personaje1, spawnPoint.position, spawnPoint.rotation);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Onpersonaje2Click()
    {        
        GameObject brujoclone = Instantiate(personaje2, spawnPoint.position, spawnPoint.rotation);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    public void Onpersonaje3oClick()
    {        
        GameObject piromanoClone = Instantiate(personaje3, spawnPoint.position, spawnPoint.rotation);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(0);
    }

    
}
