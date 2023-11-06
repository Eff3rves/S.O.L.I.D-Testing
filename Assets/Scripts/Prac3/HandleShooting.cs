using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleShooting : MonoBehaviour
{
    public List<GameObject> weaponList; // since this is parent class, all child classes can be put into it
    private int currentWeapon;
    // Start is called before the first frame update
    void Start()
    {
        for(currentWeapon = 0; currentWeapon < weaponList.Count-1; currentWeapon++)
        {
            if (weaponList[currentWeapon].gameObject.activeSelf)
            {
                break;
            }
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (!Handle_Shooting())
        {
            if (Input.mouseScrollDelta.y > 0)
            {
                if (currentWeapon == weaponList.Count - 1)
                {
                    weaponList[currentWeapon].SetActive(false);
                    currentWeapon = 0;
                    weaponList[currentWeapon].SetActive(true);
                }
                else
                {
                    weaponList[currentWeapon].SetActive(false);
                    currentWeapon++;
                    weaponList[currentWeapon].SetActive(true);

                }
            }
            else if (Input.mouseScrollDelta.y < 0)
            {
                if (currentWeapon == 0)
                {
                    weaponList[currentWeapon].SetActive(false);
                    currentWeapon = weaponList.Count - 1;
                    weaponList[currentWeapon].SetActive(true);
                }
                else
                {
                    weaponList[currentWeapon].SetActive(false);
                    currentWeapon--;
                    weaponList[currentWeapon].SetActive(true);
                }
            }
        }


    }

    public bool Handle_Shooting()
    {

        if (weaponList[currentWeapon].GetComponent<BaseWeapon>().Shoot())
        {
            weaponList[currentWeapon].GetComponent<CameraShake>().Shake();
            weaponList[currentWeapon].GetComponent<Recoils>().recoil();
            return true;
        }
        return false;
    }
}
