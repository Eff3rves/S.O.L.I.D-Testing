using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmmoManager : MonoBehaviour
{
    [SerializeField]
    private MaxAmmoCount maxAmmoCount;

    private int m_ammoInClip;

    public int ammoInClip
    {
        get { return m_ammoInClip; }
        set { m_ammoInClip = value; }
    }

    //max ammo the gun can have
    private static int maxAmmo;

    private int m_totalAmmo;

    public int totalAmmo
    {
        get { return m_totalAmmo; }
        set { m_totalAmmo = value; }
    }

    void Start()
    {
        maxAmmo = maxAmmoCount.maxAmmoCount;
        totalAmmo = maxAmmo;
        ammoInClip = maxAmmoCount.ammoPerClip;
    }

    public void Shot()
    {
        if(ammoInClip > 0)
        {
            ammoInClip--;
        }
        else if (totalAmmo > 0)
        {
            Reload();
        }
    }

    public bool cankeepShooting()
    {
        if(totalAmmo > 0 || ammoInClip > 0)
        {
            return true;
        }
        return false;
    }

    // Update is called once per frame
    void Update()
    {
        if(ammoInClip <= maxAmmoCount.ammoPerClip && totalAmmo > 0)
        {
            if(Input.GetButtonDown("Reload"))
            Reload();
        }
    }

    void Reload()
    {

        int ammoNeeded = maxAmmoCount.ammoPerClip - ammoInClip;

        if (totalAmmo >= ammoNeeded)
        {
            totalAmmo -= ammoNeeded;
            ammoInClip = maxAmmoCount.ammoPerClip;
            //Debug.Log("Reloading...");

        }
        else if (totalAmmo > 0)
        {
            ammoInClip += totalAmmo;
            totalAmmo = 0;
            //Debug.Log("Reloading...");

        }
        else
        {
            //Debug.Log("Out of Ammo!");
        }
    }


}
