using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations.Rigging;

public class PlayerCameraControllerTest : MonoBehaviour
{
    [SerializeField] float TurnSpeed = 15f, aimDuration = 0.3f;
    [SerializeField] Rig aimLayer;
    Camera mainCamera;

    [SerializeField] Transform cameraLookAt;
    public Cinemachine.AxisState xAxis;
    public Cinemachine.AxisState yAxis;

    void Start()
    {
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void FixedUpdate()
    {
        cameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0);
        xAxis.Update(Time.fixedDeltaTime);
        yAxis.Update(Time.fixedDeltaTime);
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
