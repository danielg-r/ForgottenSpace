using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Settings : MonoBehaviour
{
    public void SetQuality()
    {
        changeQualy();
        SetScreenRes();
    }

    void changeQualy()
    {
        string level = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (level)
        {
            case "Low":
                QualitySettings.SetQualityLevel(0);
                break;
            case "Medium":
                QualitySettings.SetQualityLevel(1);
                break;
            case "High":
                QualitySettings.SetQualityLevel(2);
                break;
            case "Ultra":
                QualitySettings.SetQualityLevel(3);
                break;
            case "NoShadows":
                if(QualitySettings.shadows == ShadowQuality.All)
                {
                    QualitySettings.shadows = ShadowQuality.Disable;
                }
                else QualitySettings.shadows = ShadowQuality.All;
                break;
        }
    }

    void SetScreenRes()
    {
        string index = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name;
        switch (index)
        {
            case "648":
                Screen.SetResolution(1152, 648, true);
                break;
            case "796":
                Screen.SetResolution(1360, 796, true);
                break;
            case "1080":
                Screen.SetResolution(1920, 1080, true);
                break;
            case "1440":
                Screen.SetResolution(2560, 1440, true);
                break;
        }
    }
}
