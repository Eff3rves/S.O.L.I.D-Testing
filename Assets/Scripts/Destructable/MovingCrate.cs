using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCrate : Crate,Destructable
{
    public float upLimit;
    public float forwardLimit;
    public float rightLimit;

    public void takeDmg(float damage)
    {
        OnDamaged(damage);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.forward * forwardLimit * Mathf.Sin(Time.time);
        transform.position += Vector3.right * rightLimit * Mathf.Sin(Time.time);
        transform.position += Vector3.up * upLimit * Mathf.Sin(Time.time);
    }
}
