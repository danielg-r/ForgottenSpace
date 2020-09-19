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

    public void OnplayerClick(int i) 
    {
        // 1 cryoMale, 2 cryoFemale, 3 crewMale, 4 crewFemale, 5 crewCaptainMale, 6 crewCaptainFemale, 7 junkerMale, 8 junkerFemale, 9 Medic, 10 hunterFemale

        AudioManager.Instance.Play("Click");
        PlayerSelect.Instance.CharacterSelected(i);
        this.gameObject.SetActive(false);
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        Application.Quit();
    }


}
