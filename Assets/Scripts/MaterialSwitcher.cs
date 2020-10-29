using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaterialSwitcher : MonoBehaviour
{
    [SerializeField] Material screenMaterial;
    [SerializeField] GameObject interactEffect;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H)) ChangeMaterial();
    }

    public void ChangeMaterial()
    {
        GetComponent<MeshRenderer>().material = screenMaterial;
        interactEffect.SetActive(true);
    }
}
