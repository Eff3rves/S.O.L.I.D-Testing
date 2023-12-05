using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosive : Crate, Destructable
{
    private ExplosionFactoryManager explosion;

    [SerializeField]
    GameObject explosionRadius;

    private void Start()
    {
        health = 10;
        explosion = ExplosionFactoryManager.Instance;
        explosionRadius.SetActive(false);
    }
    protected override void Destroy()
    {
        explosionRadius.SetActive(true);
        explosion.getFactory().GetProduct(transform.position);
        StartCoroutine(DestroyObj());
    }

    public void takeDmg(float damage)
    {
        OnDamaged(damage);
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(0.1f);
        Destroy(gameObject);
    }
}
