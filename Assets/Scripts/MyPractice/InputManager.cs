using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour, IObserver
{
    private float forwardInput;
    private float rightdInput;

    [SerializeField]
    float movementSpeed;

    [SerializeField]
    float jumpForce;

    [SerializeField]
    GroundCheck groundCheck;

    // Singleton instance of the 
    private static InputManager instance;
    public static InputManager Instance => instance;

    [SerializeField]
    GameObject standing;

    [SerializeField]
    GameObject crouching;

    bool isCrouch;

    private float defaultMoveSpeed;

    private bool isJump;

    private void Awake()
    {
        // Ensure there's only one instance 
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject); // Preserve across scene changes
        }
        isCrouch = false;
        defaultMoveSpeed = movementSpeed;
    }

    public void Handle_Movement(float horizontalInput, float verticalInput)
    {


        if (Input.GetButtonDown("Crouch"))
        {
            isCrouch = true;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouch = false;
        }


        standing.SetActive(!isCrouch);
        crouching.SetActive(isCrouch);

        standing.transform.rotation = gameObject.transform.rotation;
        crouching.transform.rotation = gameObject.transform.rotation;

 

        if (isCrouch)
        {
            Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y - crouching.transform.localScale.y/2, gameObject.transform.position.z);
            movementSpeed = defaultMoveSpeed / 2;

        }
        else
        {
            Camera.main.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y , gameObject.transform.position.z);
            movementSpeed = defaultMoveSpeed;

        }
        groundCheck.objheight = gameObject.transform.localScale.y;
        if (!groundCheck.GroundCheckMethod())
        {
            transform.position = standing.transform.position;
            Camera.main.transform.position = new Vector3(standing.transform.position.x, standing.transform.position.y + standing.transform.localScale.y, standing.transform.position.z);
        }
        else if (Input.GetButtonDown("Jump"))
        {
            isJump = true;
        }





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

    private void FixedUpdate()
    {
        if (isJump)
        {
            standing.GetComponent<Rigidbody>().velocity = Vector3.zero;
            standing.GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJump = false;

        }
    }

    public void UpdateObserver()
    {
        Handle_Movement(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }
}
