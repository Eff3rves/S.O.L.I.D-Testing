using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour,IObserver
{
    // Singleton instance of the AKObjPoolManager
    private static HeadBob instance;
    public static HeadBob Instance => instance;

    private Rigidbody playerRigidbody;
    private float bobbingTimer = 0.0f;
    public float bobbingSpeed = 0.18f;
    public float bobbingAmount = 0.2f;
    public float bobbingMidpoint = 0.0f;
    public float FOV;

    private float defaultBobbingSpeed;
    private float defaultFov;
    private bool isRunning;

    private void Awake()
    {
        // Ensure there's only one instance of AKObjPoolManager in the scene
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject); // Preserve across scene changes
        }
    }

    private void Start()
    {
        playerRigidbody = GetComponent<Rigidbody>();

        defaultBobbingSpeed = bobbingSpeed;
        defaultFov = Camera.main.fieldOfView;
        FOV = Camera.main.fieldOfView;
    }

    public void UpdateObserver()
    {
        ApplyHeadBob();
        HandleRun();
    }

    public Vector3 ApplyHeadBob()
    {

        float waveslice = 0.0f;
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        Vector3 cSharpConversion = Camera.main.transform.position;

        if (Mathf.Abs(horizontal) == 0 && Mathf.Abs(vertical) == 0)
        {
            bobbingTimer = 0.0f;
        }
        else
        {
            waveslice = Mathf.Sin(bobbingTimer);
            bobbingTimer += bobbingSpeed;

            if (bobbingTimer > Mathf.PI * 2)
            {
                bobbingTimer = bobbingTimer - (Mathf.PI * 2);
            }
        }

        if (waveslice != 0)
        {
            float translateChange = waveslice * bobbingAmount;

            cSharpConversion.y = bobbingMidpoint + translateChange;
        }
        else
        {
            cSharpConversion.y = bobbingMidpoint;
        }



        return new Vector3(0, cSharpConversion.y, 0);

    }


    void HandleRun()
    {
        if (Input.GetButtonDown("Sprint"))
        {
            isRunning = true;

            bobbingSpeed = defaultBobbingSpeed * 1.5f;
            FOV = defaultFov * 1.25f;
        }
        else if (Input.GetButtonUp("Sprint"))
        {
            isRunning = false;
            bobbingSpeed = defaultBobbingSpeed;
            FOV = defaultFov;
        }

        Camera.main.fieldOfView = FOV;
    }
}
