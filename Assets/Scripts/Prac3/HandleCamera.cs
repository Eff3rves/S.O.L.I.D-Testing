using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleCamera : MonoBehaviour
{

    public float mouseSensitivity = 2.0f;


    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    public void HandleCameraRotation(float axisX, float axisY)
    {
        float mouseX = axisX * mouseSensitivity;
        horizontalRotation += mouseX;

        verticalRotation -= axisY * mouseSensitivity;
        verticalRotation = Mathf.Clamp(verticalRotation, -90, 90);

        transform.Rotate(0, mouseX, 0);
        Camera.main.transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);

        //rotate player
        transform.rotation = Quaternion.Euler(0, horizontalRotation, 0);
    }
}
