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
        // 1 cryoMale, 2 cryoFemale, 3 crewMale, 4 crewFemale, 5 crewCaptainMale, 6 crewCaptainFemale, 7 junkerMale
        //8 junkerFemale, 9 Medic, 10 hunterFemale, 11 name, 12 name, 13 name, 14 name

        animator = PlayerMovement.Instance.GetComponent<Animator>();
        getCharacter = PlayerPrefs.GetInt(selectedCharacter);

        Skinnedrenderer.sharedMesh = skins[getCharacter - 1];

        if (getCharacter <= 5)
        {
            Skinnedrenderer.sharedMaterials[0] = materials[1];
        }
        else Skinnedrenderer.sharedMaterials[0] = materials[0];

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
