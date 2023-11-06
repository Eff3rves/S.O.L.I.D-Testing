using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;

public class DefultBullet : Projectile
{
    private PooledObject po;

    public Vector3 dire;

    private void Start()
    {
        po = GetComponent<PooledObject>();
        countdown = 5;
    }

    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Reset();
            po.Release();
        }


        gameObject.transform.position += dire*0.1f;
    }


    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Hit");
        if (collision.gameObject.GetComponent<Crate>() != null)
        {
            Crate c = collision.gameObject.GetComponent<Crate>();
            c.OnDamaged(damage);
            Reset();
            po.Release();
        }
    }

    private void Reset()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
    }


}
