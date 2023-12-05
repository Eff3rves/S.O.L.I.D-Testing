using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public abstract class Crate : MonoBehaviour
{
    protected float health = 20;

    public void OnDamaged(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy();
    }

    protected virtual void Destroy()
    {
        Destroy(this.gameObject);
    }
}