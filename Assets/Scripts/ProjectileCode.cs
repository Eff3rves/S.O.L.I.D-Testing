using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileCode : MonoBehaviour
{
    protected Rigidbody rb;
    [SerializeField]
    protected Transform originalLocation;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        Reset();
        
    }

    private void Reset()
    {
        rb.velocity = Vector3.zero;
        gameObject.transform.position = originalLocation.position;
        gameObject.SetActive(false);
    }
}
