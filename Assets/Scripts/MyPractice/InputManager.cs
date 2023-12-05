using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    public float movementSpeed;
    public float jumpForce;

    private Rigidbody playerRigidbody;
    private CapsuleCollider playerCollider;
    private float standingHeight;
    private float crouchingHeight;
    private float proneHeight;

    private bool isCrouching;
    private bool isJumping;
    private bool isProne;
    private bool isRunning;

    private float defaultMoveSpeed;

    private HeadBob HB;

    [SerializeField]
    private GroundCheck groundCheck;


    void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();
        playerCollider = GetComponent<CapsuleCollider>();

        // Record initial heights
        standingHeight = playerCollider.height;
        crouchingHeight = standingHeight * 0.5f;
        proneHeight = proneHeight * 0.25f;

        groundCheck.objheight = standingHeight*0.9f;
        defaultMoveSpeed = movementSpeed;
        HB = HeadBob.Instance;
    }

    void Update()
    {
        
        HandleCrouch();
        HandleProne();
        HandleJump();
        HandleRun();

    }

    void FixedUpdate()
    {
        MovePlayer();
        
        if (isJumping)
        {
            playerRigidbody.velocity = Vector3.zero;
            playerRigidbody.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isJumping = false;
        }

        Camera.main.transform.position = new Vector3(playerRigidbody.position.x, playerRigidbody.position.y + playerCollider.height / 2, playerRigidbody.position.z);
        Camera.main.transform.position += HB.ApplyHeadBob();
    }



    void MovePlayer()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        
        // Calculate movement direction based on camera
        Vector3 cameraForward = Camera.main.transform.forward;
        Vector3 cameraRight = Camera.main.transform.right;
        cameraForward.y = 0; // Ensure movement is horizontal
        cameraRight.y = 0;

        Vector3 movement = (cameraForward.normalized * verticalInput + cameraRight.normalized * horizontalInput).normalized;

        if (isCrouching)
        {
            // Adjust movement speed while crouching
            movementSpeed = defaultMoveSpeed * 0.5f;
        }
        else
        {
            movementSpeed = defaultMoveSpeed;
        }

        playerRigidbody.MovePosition(transform.position + movement * movementSpeed * Time.fixedDeltaTime);
        
    }

    void HandleCrouch()
    {
        if (Input.GetButtonDown("Crouch"))
        {
            isCrouching = true;
            playerCollider.height = crouchingHeight;
        }
        else if (Input.GetButtonUp("Crouch"))
        {
            isCrouching = false;
            playerCollider.height = standingHeight;
        }

        transform.localScale = new Vector3(transform.localScale.x, playerCollider.height/2, transform.localScale.z);
    }

    void HandleProne()
    {
        if (Input.GetKeyDown("c"))
        {
            isProne = true;
            playerCollider.height = proneHeight;
        }
        else if (Input.GetKeyUp("c"))
        {
            isProne = false;
            playerCollider.height = standingHeight;
        }

        transform.localScale = new Vector3(transform.localScale.x, playerCollider.height / 2, transform.localScale.z);
    }

    void HandleRun()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            isRunning = true;
            movementSpeed = defaultMoveSpeed * 1.5f;

        }
        else if (Input.GetButtonUp("Sprint"))
        {
            isRunning = false;

            movementSpeed = defaultMoveSpeed;

        }


    }


    void HandleJump()
    {
        if (Input.GetButtonDown("Jump") && !isCrouching && !isProne && groundCheck.GroundCheckMethod())
        {
            isJumping = true;
        }
    }

}
