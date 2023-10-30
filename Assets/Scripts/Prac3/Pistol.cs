using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pistol : BaseWeapon
{
    [SerializeField]
    CameraShake cameraShake;
    private void Start()
    {
        fireRate = 0.5f;
        cooldown = 0.5f;

    }
    // Update is called once per frame
    void Update()
    {
        cooldown += Time.deltaTime;

    }


    public override void Shoot()
    {
        if(fireRate < cooldown)
        {
            Debug.Log("Fired");
            cooldown = 0;
            RaycastHit hit;

            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100))
            {
                Crate c = hit.transform.GetComponent<Crate>();
                c.OnDamaged(10);
            }
        }

    }
}
