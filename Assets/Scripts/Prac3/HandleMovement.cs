using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleMovement : MonoBehaviour
{
    private CharacterController controller;
    float horizontalInput;
    float verticalInput;

    public float moveSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }


    public void Handle_Movement(float horizontalInput, float verticalInput)
    {

        Vector3 moveDirection = (transform.forward * verticalInput + transform.right * horizontalInput).normalized;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }



}
