using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fire : MonoBehaviour
{

    [SerializeField]
    float fireForce;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        if (Input.GetButtonDown("Fire1"))
        {
            Fired();
        }
    }

    private void Fired()
    {
        //Debug.Log("fired");
        GetComponent<BulletType>().Projectile.SetActive(true);
        GetComponent<BulletType>().Projectile.transform.position = Camera.main.transform.position;
        GetComponent<BulletType>().Projectile.transform.position += new Vector3(0, 0.5f, 0);
        GetComponent<BulletType>().Projectile.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * fireForce, ForceMode.Impulse);
    }
}
