using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCameraLERP : MonoBehaviour
{

    public bool isCustomOffset;
    public Vector3 offset;

    public float smoothSpeed = 0.1f;
    public float rotationSpeed = 2f;  // Added rotation speed for mouse control

    private float mouseX;
    private float mouseY;

    // Start is called before the first frame update
    void Start()
    {

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void OnDestroy()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    private void LateUpdate()
    {
        HandleMouseInput();  // Handle mouse input

    }

    private void HandleMouseInput()
    {
        mouseX += Input.GetAxis("Mouse X") * rotationSpeed;
        mouseY -= Input.GetAxis("Mouse Y") * rotationSpeed;
        mouseY = Mathf.Clamp(mouseY, -60f, 60f);  // Limit vertical rotation to avoid flipping

        // Apply rotation to camera's transform
        transform.rotation = Quaternion.Euler(mouseY, mouseX, 0);
    }


}
