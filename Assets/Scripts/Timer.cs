using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;
using Michsky.UI.ModernUIPack;

public class Timer : MonoBehaviour
{
    private float timeRemaining;
    private bool timerIsRunning; 
    [SerializeField] float initialTime;
    public float TimeRemaining { get => timeRemaining; }
    public bool TimerIsRunning { get => timerIsRunning; }

    [SerializeField] TextMeshProUGUI timerDisplay;
    [SerializeField] bool startAutomatically;
    [SerializeField] bool countDown;
    [SerializeField] bool useProgressBar;
    [SerializeField] ProgressBar progressBar;

    public UnityEvent2 OnTimerFinished;
    public UnityEvent2 OnTimerStarted;

    void Start()
    {
        if (startAutomatically)
        {
            timerIsRunning = true;
            EnableGraphics();
        } 
        if (countDown)
        {
            timeRemaining = initialTime;
            progressBar.currentPercent = 100f;
            progressBar.invert = true;
        } 
        else 
        {
            timeRemaining = 0;
            progressBar.currentPercent = 0f;
            progressBar.invert = false;
        }
    }

    void Update()
    {
        if (timerIsRunning && countDown)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
                progressBar.currentPercent = (timeRemaining * 100) / initialTime; 
                progressBar.isOn = true;
            }
            else 
            {
                timeRemaining = 0;
                timerIsRunning = false;
                progressBar.isOn = false;
            }
        }
        else if (timerIsRunning && !countDown)
        {
            if (timeRemaining < initialTime)
            {
                timeRemaining += Time.deltaTime;
                DisplayTime(timeRemaining);
                progressBar.currentPercent = (timeRemaining * 100) / initialTime; 
                progressBar.isOn = true;
            }
            else 
            {
                timeRemaining = initialTime;
                timerIsRunning = false;
                progressBar.isOn = false;
            }
        }
    }

    void DisplayTime(float timeToDisplay)
    {
        if (countDown) timeToDisplay += 1;       

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timerDisplay.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void StartTimer()
    {
        timerIsRunning = true;
        EnableGraphics();
    }

    public void StartTimer(float time)
    {
        Debug.Log("Iniciando timer...");
        initialTime = time;
        if (countDown)
        {
            timeRemaining = time;
            progressBar.currentPercent = 100f;
            progressBar.invert = true;
        } 
        else 
        {
            timeRemaining = 0;
            progressBar.currentPercent = 0f;
            progressBar.invert = false;
        }
        timerIsRunning = true;
        EnableGraphics();        
    }

    public void StopTimer() 
    {
        Debug.Log("Stopping time...");
        timerIsRunning = false;
        DisableGraphics();
    }

    void EnableGraphics()
    {        
        if (useProgressBar) progressBar.gameObject.SetActive(true);
        timerDisplay.gameObject.SetActive(true);
    }

    void DisableGraphics() 
    {
        if (useProgressBar) progressBar.gameObject.SetActive(false);
        timerDisplay.gameObject.SetActive(false);
    }
}
