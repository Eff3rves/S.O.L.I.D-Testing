using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionRadius : MonoBehaviour
{
    public float damage;

    [SerializeField]
    CameraShake cameraShake;


    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Crate>() != null)
        {
            Debug.Log("Hit Crate");
            Crate crate = other.GetComponent<Crate>();
            if (crate != null)
            {
                crate.OnDamaged(damage);
            }
        }
        else if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            cameraShake.Shake();
        }


    }
}

