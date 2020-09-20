using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSelect : MonoBehaviour
{
    public static PlayerSelect Instance { get; private set; }
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
        //CharacterSelected(6);
    }

    public void CharacterSelected(int CharacterInt)
    {
        // 1 cryoMale, 2 cryoFemale, 3 Alien, 4 robotFemale, 5 crewCaptainMale, 6 RichMale (el facherito), 7 medicalMale, 8 MuscleMale
        // 9 JunkyFemale, 10 HackerFemale, 11 cyberpunkMale, 12 AugmentedMale, 13 Lagartija, 14 alienCabezon, 15 CyberFemale, 16 CyberMale 

        PlayerPrefs.SetInt(selectedCharacter, CharacterInt);
    }
}
