using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.Factory;

public class MuzzleFlashFactoryManager : FactoryManager
{
    [SerializeField]
    private ConcreteFactoryMuzzleFlash muzzleFlash;
    void Update()
    {
        
        if(Listcount > weaponList.Count)
        {
            Listcount = weaponList.Count;
            return;
        }

        if (Listcount < weaponList.Count)
        {
            foreach (var weapon in weaponList)
            {
                if (weapon.GetComponent<MuzzleFlash>() != null)
                {
                    if (weapon.GetComponent<MuzzleFlash>().muzzleFlash == null)
                    {
                        weapon.GetComponent<MuzzleFlash>().muzzleFlash = muzzleFlash;
                    }
                }
            }
            Listcount = weaponList.Count;
        }



    }
}
