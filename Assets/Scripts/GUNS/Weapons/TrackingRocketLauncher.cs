using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;

public class TrackingRocketLauncher : BaseWeapon
{
    private TrackingRocketObjPoolManager RocketObjPoolManager;


    [SerializeField]
    private Transform Forward;

    [SerializeField]
    private Transform BulletSpawn;



    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.25f;
        cooldown = 0.5f;
        loadOut = LoadOutManager.Instance;
        RocketObjPoolManager = TrackingRocketObjPoolManager.Instance;
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

                Vector3 bulletDire = Vector3.Normalize(BulletSpawn.position - Forward.position);
                GameObject bull = RocketObjPoolManager.GetPooledObject().gameObject;


                bull.transform.position = BulletSpawn.position;
                //Debug.Log(bull.transform.position);
                bull.GetComponent<TrackingRocket>().dire = bulletDire;

                return true;
            }
        }
        return false;
    }
}
