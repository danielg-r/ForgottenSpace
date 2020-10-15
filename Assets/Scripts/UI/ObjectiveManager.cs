using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Michsky.UI.ModernUIPack;
using TMPro;

public class ObjectiveManager : MonoBehaviour
{
    public static ObjectiveManager Instance;
    [SerializeField] TextMeshProUGUI principalObjective, currentObjective;
    [SerializeField] ModalWindowManager objectiveUI;
    bool isActive; 

    void Awake() {
        if (Instance == null) Instance = this;
    }

    void Start()
    {
        principalObjective.text = "Averigua qué sucedió en la estación.";
        currentObjective.text = "";        
    }

    public void SetCurrentObjective(string objective) {
        currentObjective.text  = objective;
    }

    public void SetPrincipalObjective(string objective) {
        principalObjective.text  = objective;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.J)) ToggleUI();
    }

    void ToggleUI() {
        if (isActive) HideUI();
        else ShowUI();
    }

    public void ShowUI() {
        objectiveUI.OpenWindow();
        isActive = true;
    }

    public void HideUI() {
        objectiveUI.CloseWindow();
        isActive = false;
    }
}
