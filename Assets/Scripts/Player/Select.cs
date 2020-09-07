using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select : MonoBehaviour
{
    public static Select Instance { get; private set; }
    readonly string selectedCharacter = "SelectedCharacter";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void CharacterSelected(int CharacterInt)
    // 1: hombre 2: mujer
    {
        switch (CharacterInt)
        {
            case 1:
                PlayerPrefs.SetInt(selectedCharacter, 1);
                break;
            case 2:
                PlayerPrefs.SetInt(selectedCharacter, 2);
                break;
        }
    }
}
