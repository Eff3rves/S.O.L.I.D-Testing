using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{


    public Transform firePoint;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

    }

    private void Update()
    {


        HandleShooting();
    }





    private void HandleShooting()
    {

    }

}
