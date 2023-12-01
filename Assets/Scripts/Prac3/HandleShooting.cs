using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleShooting : MonoBehaviour
{
    //all weapon will have a script called weapon handler that will do all the actions,
    //the handle shooting will manage where they can shoot or switch weapon
    //to be fair the other serialised fields can also be specific observers but at this point it is only 1 script each and not a very tight coupling

    private LoadOutManager loadOut;

    [SerializeField]
    private TMP_Text ammoText;

    private GameObject currWeapon;

    private void Start()
    {
        loadOut = LoadOutManager.Instance;
    }

    private void Update()
    {
        
        if(currWeapon != loadOut.getCurrWeapon())
        {
            currWeapon = loadOut.getCurrWeapon();
        }

        if(ammoText != null)
        {
            updateAmmoText();
        }

    }

    public bool Handle_Shooting()
    {
        //check if there is a weapon in hand
        if(currWeapon != null)
        {
            AmmoManager ammoThing = currWeapon.GetComponent<AmmoManager>();


            //once the weapon is shot, start to notify every observer
            if (currWeapon.GetComponent<BaseWeapon>().Shoot())
            {
                currWeapon.GetComponent<WeaponHandler>().NotifyObservers();
                //sets loadout to cannot switch
                loadOut.canSwitch = false;
                ammoThing.Shot();
                return true;
            }

            //sets loadout to can switch
            loadOut.canSwitch = true;

               
        }

        return false;
    }

    private void updateAmmoText()
    {
        if(currWeapon != null)
        {
            AmmoManager ammoThing = currWeapon.GetComponent<AmmoManager>();
            ammoText.text = (ammoThing.ammoInClip + " / " + ammoThing.totalAmmo);
        }
        else
        {
            ammoText.text = " ";
        }

    }
}
