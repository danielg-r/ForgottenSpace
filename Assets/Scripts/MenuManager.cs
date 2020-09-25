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

    //Timer
    public float timer = 0f;
    public float d = 1.2f;
    public int mode;

    private string panelFadeIn = "Panel Open";
    private string panelFadeOut = "Panel Close";
    private string styleExpand = "Expand";

    [Header("STYLE OBJECTS")]
    public List<GameObject> objects = new List<GameObject>();

    [Header("STYLE PARENTS")]
    public List<GameObject> panels = new List<GameObject>();

    private GameObject currentPanel;
    private GameObject nextPanel;
    private GameObject styleObject;

    [Header("SETTINGS")]
    public int currentPanelIndex = 0;
    private int currentButtonlIndex = 0;
    private int currentStylelIndex = 0;

    private Animator currentPanelAnimator;
    private Animator styleAnimator;
    public Animator nextPanelAnimator;

    //ESCENA 0 = MENU / ESCENA 1 = JUEGO

    private void Start()
    {
        currentPanel = panels[currentPanelIndex];
        currentPanelAnimator = currentPanel.GetComponent<Animator>();
        currentPanelAnimator.Play(panelFadeIn);

        styleObject = objects[currentStylelIndex];
        styleAnimator = currentPanel.GetComponent<Animator>();
        styleAnimator.Play(styleExpand);

        nextPanel = panels[currentPanelIndex];
        nextPanelAnimator = nextPanel.GetComponent<Animator>();
    }

    public void Update()
    {        

       timer += Time.deltaTime;

        if (timer >= d)
        {
            switch (mode)
            {
                case 1:
                    //canvas2Players.SetActive(true);
                    PanelAnim(1);
                    break;
                case 2:
                    //canvas1Play.SetActive(true);
                    PanelAnim(0);
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

        //canvas1Play.SetActive(false);
    }
    public void OnReturnClick()
    {
        AudioManager.Instance.Play("Click");
        camara1Play.SetActive(true);
        camara2Players.SetActive(false);


        timer = 0f;
        mode = 2;
        
        //canvas2Players.SetActive(false);
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

    public void PanelAnim(int newPanel)
    {
        if (newPanel != currentPanelIndex)
        {
            currentPanel = panels[currentPanelIndex];

            currentPanelIndex = newPanel;
            nextPanel = panels[currentPanelIndex];

            currentPanelAnimator = currentPanel.GetComponent<Animator>();
            nextPanelAnimator = nextPanel.GetComponent<Animator>();

            currentPanelAnimator.Play(panelFadeOut);
            nextPanelAnimator.Play(panelFadeIn);

            currentStylelIndex = newPanel;
            styleAnimator = currentPanel.GetComponent<Animator>();
            styleAnimator.Play(styleExpand);
        }
    }
}
