using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;

public class AK : BaseWeapon
{
    private AKObjPoolManager aKObjPoolManager;

    [SerializeField]
    private Transform Forward;

    [SerializeField]
    private Transform BulletSpawn;

    [SerializeField]
    private GameObject bullet;



    bool btnDown = false;

    bool fired = false;
    private void Start()
    {
        fireRate = 0.15f;
        cooldown = 0;
        aKObjPoolManager = AKObjPoolManager.Instance;
    }

    private void Update()
    {
        cooldown += Time.deltaTime;
        fired = false;
        if (btnDown && ammoManager.cankeepShooting())
        {

            if (fireRate < cooldown)
            {
                //Debug.Log("Fired");
                cooldown = 0;

                Vector3 bulletDire = Vector3.Normalize(Forward.position - gameObject.transform.position);
                GameObject bull = aKObjPoolManager.GetPooledObject().gameObject;


                bull.transform.position = BulletSpawn.position;
                //Debug.Log(bull.transform.position);
                bull.GetComponent<DefultBullet>().dire = bulletDire;

                fired = true;
            }

        }
        else
        {
            fired = false;
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

        return fired;
    }

}
