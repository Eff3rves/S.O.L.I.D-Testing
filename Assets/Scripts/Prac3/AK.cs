using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;

public class AK : BaseWeapon
{
    [SerializeField]
    private ObjectPool OP;

    [SerializeField]
    private Transform dire;

    [SerializeField]
    private GameObject bullet;

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
                //Debug.Log("Fired");
                cooldown = 0;

                Vector3 bulletDire = Vector3.Normalize(dire.position - gameObject.transform.position);
                GameObject bull = OP.GetPooledObject().gameObject;
                //bull.transform.position = dire.position;
                //bull.GetComponent<DefultBullet>().dire = bulletDire;

                bull.transform.position = dire.position;
                Debug.Log(bull.transform.position);
                bull.GetComponent<DefultBullet>().dire = bulletDire;

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
