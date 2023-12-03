using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;

public class TrackingRocket : Projectile
{
    private PooledObject po;

    public Vector3 dire;

    public Transform Target = null;

    private ExplosionFactoryManager explosion;

    [SerializeField]
    private GameObject SC;

    [SerializeField]
    ExplosionRadius explosionRadius;


    private BoxCollider BC;

    private void Start()
    {
        po = GetComponent<PooledObject>();
        countdown = 5;
        explosion = ExplosionFactoryManager.Instance;
        BC = GetComponent<BoxCollider>();
        SC.SetActive(false);
        explosionRadius.damage = damage;
    }


    private void Update()
    {
        countdown -= Time.deltaTime;

        if (countdown <= 0)
        {
            Reset();
            po.Release();
        }



        if(Target != null)
        {
            dire = Vector3.Normalize(Target.position - transform.position);
        }

        gameObject.transform.position += dire * 0.1f;
        gameObject.transform.rotation = Quaternion.LookRotation(dire, Vector3.up);
    }


    private void OnCollisionEnter(Collision collision)
    {

        if (!collision.gameObject.CompareTag("Player"))
        {

            SC.SetActive(true);
            BC.enabled = false;

            explosion.getFactory().GetProduct(transform.position);

            //set a time limit before reseting the rocket so it does what its suppose to before being deactivated
            StartCoroutine(resetProjectile());
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent <Crate>() != null)
        {
            
            Target = other.gameObject.transform;
        }
    }

    private void Reset()
    {
        gameObject.transform.position = new Vector3(0, 0, 0);
        countdown = 5;
        SC.SetActive(false);
        BC.enabled = true;
    }

    IEnumerator resetProjectile()
    {
        yield return new WaitForSeconds(0.1f);
        Reset();
        po.Release();
    }
}
