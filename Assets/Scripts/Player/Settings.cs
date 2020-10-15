using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class Settings : MonoBehaviour
{
    [SerializeField] AudioMixer mixer;
    [SerializeField] Dropdown resolutionDropdown;
    float volumeInitial;
    int activeScreenResIndex;
    public Resolution[] resolutions;

    private void Start()
    {
        volumeInitial = PlayerPrefs.GetFloat("vol");
        activeScreenResIndex = PlayerPrefs.GetInt("screen res index");
        bool isFullscreenInitial = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;
        mixer.SetFloat("Volume", volumeInitial);
        SetFullscreen(isFullscreenInitial);

        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        foreach (Resolution resolution in resolutions)
        {
            resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
        }
        resolutionDropdown.value = activeScreenResIndex;
        SetScreenResolution(activeScreenResIndex);
    }

    public void setVolume(float volume)
    {
        mixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("vol", volume);
    }

    public void SetQuality(int index)
    {
        QualitySettings.SetQualityLevel(index);
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
            SetScreenResolution(activeScreenResIndex);
        }

        PlayerPrefs.SetInt("fullscreen", ((isFullscreen) ? 1 : 0));
    }

    public void SetScreenResolution(int index)
    {
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen);
        activeScreenResIndex = index;
        PlayerPrefs.SetInt("screen res index", activeScreenResIndex);
    }

    public void ChangeShadows(bool isShadow)
    {
        if (isShadow == false)
        {
            QualitySettings.shadows = ShadowQuality.Disable;
        }
        else QualitySettings.shadows = ShadowQuality.All;
    }                
}
