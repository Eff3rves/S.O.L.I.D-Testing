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

        HandleMovement.Handle_Movement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        handleShooting.Handle_Shooting();
        handleCamera.HandleCameraRotation(Input.GetAxis("Mouse X"), Input.GetAxis("Mouse Y"));
    }


}
