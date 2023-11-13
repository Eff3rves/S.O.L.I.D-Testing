using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    private float forwardInput;
    private float rightdInput;

    [SerializeField]
    float movementSpeed;



    public void Handle_Movement(float horizontalInput, float verticalInput)
    {
        rightdInput = horizontalInput;
        forwardInput = verticalInput;
        Vector3 cameraForward = Camera.main.transform.forward;

        Vector3 cameraRight = Camera.main.transform.right;
        //Debug.Log(cameraForward);
        cameraForward = new Vector3(cameraForward.x, 0, cameraForward.z);
        cameraRight = new Vector3(cameraRight.x, 0, cameraRight.z);

        transform.localPosition += cameraForward.normalized * forwardInput * movementSpeed * 0.01f;
        transform.localPosition += cameraRight.normalized * rightdInput * movementSpeed * 0.01f;
    }
}
