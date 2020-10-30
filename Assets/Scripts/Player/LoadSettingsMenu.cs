using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class LoadSettingsMenu : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    float volumeInitial;
    bool isFullscreenInitial;

    void Start()
    {
        volumeInitial = PlayerPrefs.GetFloat("vol");
        isFullscreenInitial = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;

        setVolume(volumeInitial);
        SetFullscreen(isFullscreenInitial);
    }

    public void setVolume(float volume)
    {
        mixer.SetFloat("Volume", volume);
    }

    public void SetFullscreen(bool isFullscreen)
    {
        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }

        else
        {
            //SetScreenResolution(activeScreenResIndex);
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 2];
            Screen.SetResolution(maxResolution.width, maxResolution.height, false);
        }
    }
}
