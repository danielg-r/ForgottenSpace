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
        loadingScreen = FindObjectOfType<LoadingScreen>();
        audioListener = FindObjectOfType<AudioListener>();
        loadingScreen.onFinishEvents.AddListener(playableDirector.Play); 
        loadingScreen.onFinishEvents.AddListener(EnableAudio);
        loadingScreen.onFinishEvents.AddListener(EnablePauseSystem);
    }

    void EnableAudio()
    {
        audioListener.enabled = true;
    }

    void EnablePauseSystem()
    {
        UIDeathControl.Instance.enabled = true;
    }
}
