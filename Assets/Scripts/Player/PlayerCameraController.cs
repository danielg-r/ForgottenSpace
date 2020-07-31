using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCameraController : MonoBehaviour
{
    [SerializeField] float TurnSpeed = 15, zoomSpeed = 2;
    //[SerializeField] Transform LookAt, Obstruction;
    Camera mainCamera;

    void Start()
    {
        //Obstruction = LookAt;
        mainCamera = Camera.main;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        float yawCamera = mainCamera.transform.rotation.eulerAngles.y;
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(0, yawCamera, 0), TurnSpeed * Time.fixedDeltaTime);
        //ViewObstructed();
    }

    /*void ViewObstructed()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, LookAt.position - transform.position, out hit, 4.5f))
        {
            if(hit.collider.gameObject.tag != "Player")
            {
                Obstruction = hit.transform;
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.ShadowsOnly;

                if(Vector3.Distance(Obstruction.position, transform.position) >= 3f && Vector3.Distance(transform.position, LookAt.position) >= 1.5f)
                {
                    transform.Translate(Vector3.forward * zoomSpeed * Time.deltaTime);
                }
            }
            else
            {
                Obstruction.gameObject.GetComponent<MeshRenderer>().shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                if(Vector3.Distance(transform.position, LookAt.position) < 4.5f)
                {
                    transform.Translate(Vector3.back * zoomSpeed * Time.deltaTime);
                }
            }
        }
    }*/
}
