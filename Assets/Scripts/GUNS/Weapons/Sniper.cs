using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : BaseWeapon,baseAim
{

    GameObject scopedCrosshair;

    bool isScoped = false;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.25f;
        cooldown = 0.5f;
        loadOut = LoadOutManager.Instance;
        scopedCrosshair = GameObject.Find("ScopedCrosshair");
    }


    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        Aim();
    }

    public void Aim()
    {
        if (Input.GetButtonDown("Fire2"))
        {
            isScoped = true;

        }
        else if(Input.GetButtonUp("Fire2")) {
            isScoped = false; 
        }
        gameObject.GetComponent<MeshRenderer>().enabled=!isScoped;
        scopedCrosshair.SetActive(isScoped);
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
                    if (hit.transform.GetComponent<Crate>() != null)
                    {
                        Crate c = hit.transform.GetComponent<Crate>();
                        c.OnDamaged(20);
                    }

                }

                return true;
            }
        }
        return false;
    }
}
