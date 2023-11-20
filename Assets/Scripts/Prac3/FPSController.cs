using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    [SerializeField]
    HandleCamera handleCamera;
    [SerializeField]
    InputManager HandleMovement;
    [SerializeField]
    HandleShooting handleShooting;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {
        Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y + gameObject.transform.localScale.y, gameObject.transform.position.z);
        //Camera.main.transform.rotation = gameObject.transform.rotation;

        HandleMovement.Handle_Movement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        handleCamera.HandleCameraRotation(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
        handleShooting.Handle_Shooting();

    }

}
