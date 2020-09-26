using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.LSS;
using UnityEngine.Playables;

public class LoadingScreenEvent : MonoBehaviour
{
    LoadingScreen loadingScreen;
    [SerializeField] PlayableDirector playableDirector;
    AudioListener audioListener;

    void Start()
    {
        AudioListener.volume = 0;
        loadingScreen = FindObjectOfType<LoadingScreen>();
        if (loadingScreen != null)
        {
            loadingScreen.onFinishEvents.AddListener(playableDirector.Play); 
            loadingScreen.onFinishEvents.AddListener(EnablePauseSystem);
        }
    }

    void EnablePauseSystem()
    {
        UIDeathControl.Instance.enabled = true;
    }
}
