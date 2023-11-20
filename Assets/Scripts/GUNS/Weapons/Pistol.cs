using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.Factory;


public class Pistol : BaseWeapon
{

    private void Start()
    {
        fireRate = 0.25f;
        cooldown = 0.5f;

    }
    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;

    }


    public override bool Shoot()
    {
        if (Input.GetButtonDown("Fire1") && ammoManager.cankeepShooting())
        {
            if (fireRate < cooldown)
            {
                //Debug.Log("Fired");
                cooldown = 0;
                RaycastHit hit;

                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
                {
                    if(hit.transform.GetComponent<Crate>() != null)
                    {
                        Crate c = hit.transform.GetComponent<Crate>();
                        c.OnDamaged(10);
                    }

                }

                return true;
            }
        }
        return false;
    }
}
