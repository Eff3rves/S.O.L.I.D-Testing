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

    private bool isReloading;

    Quaternion originalRotation;

    public float time2Reload;

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
        originalRotation = transform.localRotation;
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
        if(isReloading) return false;

        if (totalAmmo > 0 || ammoInClip > 0)
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
            isReloading = true;
            StartCoroutine(ReloadAnimation(time2Reload));
            
        }
        else if (totalAmmo > 0)
        {
            ammoInClip += totalAmmo;
            totalAmmo = 0;
            //Debug.Log("Reloading...");
            isReloading = true;
            StartCoroutine(ReloadAnimation(time2Reload));
        }

    }

    IEnumerator ReloadAnimation(float reloadTime)
    {

        float elapsedTime = 0.0f;
        Quaternion targetRotation = Quaternion.Euler(originalRotation.eulerAngles.x, originalRotation.eulerAngles.y, 45);

        while (elapsedTime < 0.5f) 
        {
            elapsedTime += Time.deltaTime;

            // Rotate the gun during reload
            transform.localRotation = Quaternion.Lerp(originalRotation, targetRotation, elapsedTime / 0.5f);

            yield return null;
        }

        // Ensure the gun finishes at the target rotation
        transform.localRotation = targetRotation;

        yield return new WaitForSeconds(reloadTime);

        // Return the gun to its original rotation
        elapsedTime = 0.0f;
        while (elapsedTime < 0.5f) 
        {
            elapsedTime += Time.deltaTime;

            // Rotate back to the original rotation
            transform.localRotation = Quaternion.Lerp(targetRotation, originalRotation, elapsedTime / 0.5f);

            yield return null;
        }

        // Ensure the gun finishes at the original rotation
        transform.localRotation = originalRotation;

        isReloading = false;
    }
}
