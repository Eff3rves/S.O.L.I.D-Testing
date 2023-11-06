using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AK : BaseWeapon
{
    bool btnDown = false;
    private void Start()
    {
        fireRate = 0.1f;
        cooldown = 0;

    }

    private void Update()
    {
        cooldown += Time.deltaTime;

        if (btnDown)
        {
            if (fireRate < cooldown)
            {
                Debug.Log("Fired");
                cooldown = 0;


            }
        }

    }

    public override bool Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            btnDown = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            btnDown = false;
        }

        return btnDown;
    }
}
