using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    private float forwardInput;
    private float rightdInput;

    [SerializeField]
    float movementSpeed;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //controlling forward and right left movement
        rightdInput = Input.GetAxis("Horizontal");
        forwardInput = Input.GetAxis("Vertical");
        Vector3 cameraForward = Camera.main.transform.forward;
        
        Vector3 cameraRight = Camera.main.transform.right;
        //Debug.Log(cameraForward);
        cameraForward = new Vector3(cameraForward.x,0,cameraForward.z);
        cameraRight = new Vector3(cameraRight.x, 0, cameraRight.z);
        transform.position += cameraForward.normalized * forwardInput*movementSpeed;
        transform.position += cameraRight.normalized * rightdInput*movementSpeed;
    }
}
