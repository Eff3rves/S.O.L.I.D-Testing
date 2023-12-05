using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turret : BaseWeapon
{
    private AKObjPoolManager aKObjPoolManager;
    [SerializeField]
    private Transform Forward;

    [SerializeField]
    private Transform BulletSpawn;

    bool fired = false;
    bool btnDown = false;


    public override bool Shoot()
    {
        return fired;
    }

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.5f;
        cooldown = 0;
        aKObjPoolManager = AKObjPoolManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {

        cooldown += Time.deltaTime;
        fired = false;
        if (btnDown && ammoManager.cankeepShooting())
        {

            if (fireRate < cooldown)
            {
                //Debug.Log("Fired");
                cooldown = 0;

                Vector3 bulletDire = Vector3.Normalize(BulletSpawn.position - Forward.position);
                GameObject bull = aKObjPoolManager.GetPooledObject().gameObject;


                bull.transform.position = BulletSpawn.position;
                //Debug.Log(bull.transform.position);
                bull.GetComponent<DefultBullet>().dire = bulletDire;

                fired = true;
            }

        }
        else
        {
            fired = false;
        }

        //once the weapon is shot, start to notify every observer
        if (Shoot())
        {
            GetComponent<WeaponHandler>().NotifyObservers();
            ammoManager.Shot();
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            transform.LookAt(other.transform);

            // Reset x and z rotations while keeping y-axis rotation unchanged
            Vector3 newRotation = new Vector3(0, transform.eulerAngles.y+90, 0);
            transform.rotation = Quaternion.Euler(newRotation);

            btnDown = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {


            btnDown = false;
        }
    }
}
