using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AirSystem : MonoBehaviour
{

    [SerializeField] private int minutes;
    [SerializeField] private int seconds;

    private int m, s;
    [SerializeField] private TextMeshProUGUI timerText;
    [SerializeField] private GameObject TimerUI;

    [SerializeField] private GameObject LooseUI;

    void Start()
    {
        
    }
    
    public void startTimer() //Cuando se acabe la cinematica 
        //DONDE SE LE EXPLICA QUE TIENE QUE IR A PRENDER EL GENERADOR
    {
        m = minutes;
        s = seconds;
        writerTimer(m, s);
        TimerUI.SetActive(true);
        Invoke("UpdateTimer", 1f);

    }
    public void StopTimer() //Cuando prenda la energia
    {
        TimerUI.SetActive(false);
        CancelInvoke();
    }
    private void UpdateTimer()
    {
        s--;
        if (s < 0)
        {
            if (m == 0)
            {
                LooseUI.SetActive(true);
                StopTimer();
            }
            else
            {
                m--;
                s = 59;
            }
        }

        writerTimer(m, s);
        Invoke("UpdateTimer", 1f);
    }

    private void writerTimer(int m,int s)
    {
        if (s < 10)
        {
            timerText.text = m.ToString() + ":0" + s.ToString();
        }
        else
        {
            timerText.text = m.ToString() + ":" + s.ToString();
        }
    }


}
