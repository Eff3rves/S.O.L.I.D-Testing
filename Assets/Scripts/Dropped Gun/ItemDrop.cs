using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    [SerializeField]
    private AmmoManager ammoManager;

    private ItemPickUp itemPickUp;

    [SerializeField]
    private GameObject weaponDropped;

    [SerializeField]
    private float dropForce = 5f;

    private void Update()
    {
        if (Input.GetButtonDown("Drop"))
        {
            GameObject weapon;
            weapon = Instantiate(weaponDropped, gameObject.transform.position, Quaternion.identity);
            if(weapon.GetComponent<ItemPickUp>() != null)
            {
                itemPickUp = weapon.GetComponent<ItemPickUp>();
                itemPickUp.ammoInClip = ammoManager.ammoInClip;
                itemPickUp.totalAmmo = ammoManager.totalAmmo;
            }

            // Apply an impulse force in the direction the camera is facing
            Rigidbody weaponRb = weapon.GetComponent<Rigidbody>();
            if (weaponRb != null)
            {
                Vector3 forceDirection = Camera.main.transform.forward; // Use Camera.main to get the main camera
                weaponRb.AddForce(forceDirection * dropForce, ForceMode.Impulse);
            }

            Destroy(gameObject);
        }
    }
}
