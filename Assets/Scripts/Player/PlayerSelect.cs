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
    }

    public void CharacterSelected(int CharacterInt)
    {
        // 1 cryoMale, 2 cryoFemale, 3 crewMale, 4 crewFemale, 5 crewCaptainMale, 6 crewCaptainFemale, 7 junkerMale, 8 junkerFemale, 9 Medic, 10 hunterFemale

        PlayerPrefs.SetInt(selectedCharacter, CharacterInt);
    }
}
