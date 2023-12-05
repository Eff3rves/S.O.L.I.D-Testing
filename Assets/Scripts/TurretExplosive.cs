using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretExplosive : Crate, Destructable
{


    private ExplosionFactoryManager explosion;

    [SerializeField]
    GameObject explosionRadius;

    [SerializeField]
    SphereCollider detectionRadius;

    private void Start()
    {
        health = 10;
        explosion = ExplosionFactoryManager.Instance;
        explosionRadius.SetActive(false);
    }
    protected override void Destroy()
    {
        detectionRadius.enabled = false;

        StartCoroutine(DestroyObj());
    }

    public void takeDmg(float damage)
    {
        OnDamaged(damage);
    }

    IEnumerator DestroyObj()
    {
        yield return new WaitForSeconds(0.2f);
        explosionRadius.SetActive(true);
        explosion.getFactory().GetProduct(transform.position);
        Destroy(gameObject);
    }

}
