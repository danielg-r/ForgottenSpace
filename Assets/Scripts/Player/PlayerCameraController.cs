using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

using UnityEngine.Animations.Rigging;

public class PlayerCameraController : MonoBehaviour
{
    public static PlayerCameraController Instance {get; set;}

    float TurnSpeed = 15f, aimDuration = 0.1f;
    [SerializeField] Rig aimLayer;
    public TextMeshProUGUI canvasText;

    Camera mainCamera;

    private void Awake()
    {
        Instance = this;
    }

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), TurnSpeed * Time.fixedDeltaTime);
    }

    private void Update()
    {
        if (Input.GetMouseButton(1))
        {
            aimLayer.weight += Time.deltaTime / aimDuration;
        }
        else
        {
            aimLayer.weight -= Time.deltaTime / aimDuration;
        }
    }
}
