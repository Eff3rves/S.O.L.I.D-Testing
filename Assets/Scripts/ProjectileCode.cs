using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileCode : MonoBehaviour
{
    private Rigidbody rb;
    [SerializeField]
    private Transform originalLocation;
    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reset();
        }
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
