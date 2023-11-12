using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;

public class AKObjPoolManager : ObjPoolManager
{
 
    void Update()
    {

        if (Listcount > weaponList.Count)
        {
            Listcount = weaponList.Count;
            return;
        }

        if (Listcount < weaponList.Count)
        {
            foreach (var weapon in weaponList)
            {
                if (weapon.GetComponent<AK>() != null)
                {
                    if (weapon.GetComponent<AK>().OP == null)
                    {
                        weapon.GetComponent<AK>().OP = OP;
                    }
                }
            }
            Listcount = weaponList.Count;
        }
       


    }
}
