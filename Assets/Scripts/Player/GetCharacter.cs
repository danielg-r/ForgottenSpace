using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCharacter : MonoBehaviour
{
    public static GetCharacter Instance { get; private set; }

    readonly string selectedCharacter = "SelectedCharacter";
    int getCharacter;
    [SerializeField] Mesh[] skins;
    [SerializeField] Material[] materials;
    Animator animator;

    [HideInInspector] public bool IsMale;

    [SerializeField] SkinnedMeshRenderer Skinnedrenderer;
    [SerializeField] SkinnedMeshRenderer SkinnedrendererMimido;

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

    void Start()
    {
        // 1 cryoMale, 2 cryoFemale, 3 Alien, 4 robotFemale, 5 crewCaptainMale, 6 RichMale (el facherito), 7 medicalMale, 8 MuscleMale
        // 9 JunkyFemale, 10 HackerFemale, 11 cyberpunkMale, 12 AugmentedMale, 13 Lagartija, 14 alienCabezon, 15 CyberFemale, 16 CyberMale 

        animator = PlayerMovement.Instance.GetComponent<Animator>();
        getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        Skinnedrenderer.sharedMesh = skins[getCharacter - 1];
        SkinnedrendererMimido.sharedMesh = skins[getCharacter - 1];

        if (getCharacter <= 5)
        {
            Skinnedrenderer.material = materials[1];
            SkinnedrendererMimido.material = materials[1];
        }
        else
        {
            Skinnedrenderer.material = materials[0];
            SkinnedrendererMimido.material = materials[0];
        }
            

        if (getCharacter == 2 || getCharacter == 4 || getCharacter == 9 || getCharacter == 10 || getCharacter == 15)
        {
            IsMale = false;
        }
        else IsMale = true;

        if (IsMale)
        {
            animator.runtimeAnimatorController = Resources.Load("Player") as RuntimeAnimatorController;
        }
        else animator.runtimeAnimatorController = Resources.Load("PlayerWoman") as RuntimeAnimatorController;
    }
}
