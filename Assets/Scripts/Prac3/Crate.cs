using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;

public class Crate : MonoBehaviour
{
    private float health = 20;

    public void OnDamaged(float damage)
    {
        health -= damage;
        if (health <= 0) Destroy();
    }

    private void Destroy()
    {
        Destroy(this.gameObject);
    }
}