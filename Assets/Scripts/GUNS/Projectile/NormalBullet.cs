using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalBullet : MonoBehaviour,ProjectileCode
{
    protected Rigidbody rb;
    [SerializeField]
    protected Transform originalLocation;


    private void Reset() {
        rb = gameObject.GetComponent<Rigidbody>();

        rb.velocity = Vector3.zero;
        gameObject.transform.position = originalLocation.position;
        gameObject.SetActive(false);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Reset();
    }


}


