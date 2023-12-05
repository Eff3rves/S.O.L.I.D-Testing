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
    private Transform dropLoc;

    LoadOutManager loadOut;

    private void Start()
    {
        loadOut = LoadOutManager.Instance;
    }

    private void Update()
    {
        if (Input.GetButtonDown("Drop"))
        {
            GameObject weapon;
            weapon = Instantiate(weaponDropped, dropLoc.position, Quaternion.identity);
            if(weapon.GetComponent<ItemPickUp>() != null)
            {
                itemPickUp = weapon.GetComponent<ItemPickUp>();
                itemPickUp.ammoInClip = ammoManager.ammoInClip;
                itemPickUp.totalAmmo = ammoManager.totalAmmo;
            }
            loadOut.RemoveWeapon();
            Destroy(gameObject);
        }
    }
}
