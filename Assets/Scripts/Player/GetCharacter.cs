using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetCharacter : MonoBehaviour
{
    readonly string selectedCharacter = "SelectedCharacter";
    int getCharacter;
    [SerializeField] GameObject[] skins;
    Animator animator;

    void Start()
    {
        animator = PlayerMovement.Instance.GetComponent<Animator>();
        getCharacter = PlayerPrefs.GetInt(selectedCharacter);
        // 1: hombre 2: mujer
        switch (getCharacter)
        {
            case 1:
                skins[0].SetActive(true);
                skins[1].SetActive(false);
                animator.runtimeAnimatorController = Resources.Load("Player") as RuntimeAnimatorController;
                break;
            case 2:
                skins[0].SetActive(false);
                skins[1].SetActive(true);
                animator.runtimeAnimatorController = Resources.Load("PlayerWoman") as RuntimeAnimatorController;
                break;
        }
    }
}
