using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleShooting : MonoBehaviour
{
    public List<BaseWeapon> weaponList; // since this is parent class, all child classes can be put into it
    private int currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            if (currentWeapon == weaponList.Count - 1)
            {
                weaponList[currentWeapon].gameObject.SetActive(false);
                currentWeapon = 0;
                weaponList[currentWeapon].gameObject.SetActive(true);
            }
            else
            {
                weaponList[currentWeapon].gameObject.SetActive(false);
                currentWeapon++;
                weaponList[currentWeapon].gameObject.SetActive(true);
                
            }
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            if (currentWeapon == 0)
            {
                weaponList[currentWeapon].gameObject.SetActive(false);
                currentWeapon = weaponList.Count - 1;
                weaponList[currentWeapon].gameObject.SetActive(true);
            }
            else
            {
                weaponList[currentWeapon].gameObject.SetActive(false);
                currentWeapon--;
                weaponList[currentWeapon].gameObject.SetActive(true);
            }
        }
        Handle_Shooting();
    }

    void Handle_Shooting()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            weaponList[currentWeapon].Shoot();
        }
    }
}
