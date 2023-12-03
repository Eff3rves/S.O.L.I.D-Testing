using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sniper : BaseWeapon,baseAim
{

    GameObject scopedCrosshair;

    bool isScoped = false;

    float DefaultFOV;

    public float zoom;

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.25f;
        cooldown = 0.5f;
        loadOut = LoadOutManager.Instance;

        scopedCrosshair = GameObject.Find("Canvas");
        foreach(Transform i in scopedCrosshair.transform)
        {
            if(i.gameObject.name == "ScopedCrosshair")
            {
                scopedCrosshair = i.gameObject;
                break;
            }
        }

        DefaultFOV = Camera.main.fieldOfView;
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
            Camera.main.fieldOfView = DefaultFOV - zoom;
        }
        else if(Input.GetButtonUp("Fire2")) {
            isScoped = false;
            Camera.main.fieldOfView = DefaultFOV;
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
