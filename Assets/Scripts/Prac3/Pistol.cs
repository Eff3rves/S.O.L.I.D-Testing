using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseWeapon
{
    private void Start()
    {
        fireRate = 2;
        cooldown = 0;

    }
    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }


    public override void Shoot()
    {
        if(fireRate < cooldown)
        {
            Debug.Log("Fired");
            cooldown = 0;
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
            {
                Crate c = hit.transform.GetComponent<Crate>();
                c.OnDamaged(10);
            }
        }

    }
}
