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

        if (other.transform.GetComponent<Destructable>() != null)
        {
            other.transform.GetComponent<Destructable>().takeDmg(10);
        }

        else if (other.CompareTag("Player"))
        {
            Debug.Log("Hit Player");
            cameraShake.Shake();
        }


    }
}

