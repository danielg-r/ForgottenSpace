using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using Michsky.UI.ModernUIPack;
using Cinemachine;

public class Settings : MonoBehaviour
{
    [SerializeField] CinemachineFreeLook cam;
    [SerializeField] AudioMixer mixer;
    [SerializeField] CustomDropdown dropdownResolution;
    [SerializeField] CustomDropdown dropdownQuality;
    [SerializeField] Slider sliderVolume;
    [SerializeField] Slider sliderMouseX;
    [SerializeField] Slider sliderMouseY;
    [SerializeField] Toggle toggleFullScreen;
    [SerializeField] Toggle toggleShadows;

    float volumeInitial;
    float xInitial;
    float yInitial;
    int activeScreenResIndex;
    bool isFullscreenInitial;
    bool isShadowsInitial;
    public Resolution[] resolutions;

    private void Start()
    {
        xInitial = PlayerPrefs.GetFloat("Sensibility_X");
        yInitial = PlayerPrefs.GetFloat("Sensibility_Y");
        volumeInitial = PlayerPrefs.GetFloat("vol");
        activeScreenResIndex = PlayerPrefs.GetInt("screen res index");
        isFullscreenInitial = (PlayerPrefs.GetInt("fullscreen") == 1) ? true : false;
        isShadowsInitial = (PlayerPrefs.GetInt("shadows") == 1) ? true : false;

        setVolume(volumeInitial);
        setSensibilityMouseX(xInitial);
        setSensibilityMouseY(yInitial);
        SetFullscreen(isFullscreenInitial);
        setShadows(isShadowsInitial);
        /*
        resolutions = Screen.resolutions;
        dropdownResolution.ClearItems();
        foreach (Resolution resolution in resolutions)
        {
            //resolutionDropdown.options.Add(new Dropdown.OptionData(resolution.ToString()));
            dropdownResolution.AddNewItem();
            dropdownResolution.SetItemTitle(resolution.width.ToString() + "x" + resolution.height.ToString());
        }
        //resolutionDropdown.value = activeScreenResIndex;
        SetScreenResolution(activeScreenResIndex);
        */
        sliderVolume.value = volumeInitial;
        sliderMouseX.value = xInitial;
        sliderMouseY.value = yInitial;
        toggleFullScreen.isOn = isShadowsInitial;
        toggleFullScreen.isOn = isFullscreenInitial;
    }

    public void setVolume(float volume)
    {
        mixer.SetFloat("Volume", volume);
        PlayerPrefs.SetFloat("vol", volume);
    }

    public void setSensibilityMouseX(float delta)
    {
        cam.m_XAxis.m_MaxSpeed = delta;
        PlayerPrefs.SetFloat("Sensibility_X", delta);
    }

    public void setSensibilityMouseY(float delta)
    {
        cam.m_YAxis.m_MaxSpeed = delta;
        PlayerPrefs.SetFloat("Sensibility_Y", delta);
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
            //SetScreenResolution(activeScreenResIndex);
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions[allResolutions.Length - 2];
            Screen.SetResolution(maxResolution.width, maxResolution.height, false);
        }

        PlayerPrefs.SetInt("fullscreen", ((isFullscreen) ? 1 : 0));
    }

    /*public void SetScreenResolution(int index)
    {
        Screen.SetResolution(resolutions[index].width, resolutions[index].height, Screen.fullScreen);
        activeScreenResIndex = index;
        PlayerPrefs.SetInt("screen res index", activeScreenResIndex);
    }*/

    public void setShadows(bool isShadow)
    {
        if (isShadow == false)
        {
            QualitySettings.shadows = ShadowQuality.Disable;
        }
        else QualitySettings.shadows = ShadowQuality.All;
        PlayerPrefs.SetInt("shadows", ((isShadow) ? 1 : 0));
    }                
}
