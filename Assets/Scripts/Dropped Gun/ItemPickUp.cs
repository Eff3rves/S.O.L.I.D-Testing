using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemPickUp : MonoBehaviour
{
    [SerializeField]
    private GameObject weaponPrefab;

    private static int m_totalAmmo;

    public int totalAmmo
    {
        get { return m_totalAmmo; }
        set { m_totalAmmo = value; }
    }

    private static int m_ammoInClip;

    public int ammoInClip
    {
        get { return m_ammoInClip; }
        set { m_ammoInClip = value; }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject player;
            player = collision.gameObject;
            GameObject weapontaken;
            weapontaken = Instantiate(weaponPrefab, Camera.main.transform) ;
            AmmoManager ammoManager = weapontaken.GetComponent<AmmoManager>();
            ammoManager.totalAmmo = m_totalAmmo;
            ammoManager.ammoInClip = m_ammoInClip;
            player.GetComponent<LoadOutManager>().addWeapon(weapontaken);
            Destroy(gameObject);
        }

    }

  
}
