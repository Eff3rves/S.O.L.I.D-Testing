using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HandleShooting : MonoBehaviour,IObserver
{ 

    private LoadOutManager loadOut;

    [SerializeField]
    private TMP_Text ammoText;

    private GameObject currWeapon;

    // Singleton instance
    private static HandleShooting instance;
    public static HandleShooting Instance => instance;


    private void Awake()
    {
        // Ensure there's only one instance 
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject); // Preserve across scene changes
        }
    }

    private void Start()
    {
        loadOut = LoadOutManager.Instance;
    }

    private void Update()
    {
        
        if(currWeapon != loadOut.getCurrWeapon())
        {
            currWeapon = loadOut.getCurrWeapon();
            if(currWeapon != null) currWeapon.SetActive(true);

        }

        if(ammoText != null && currWeapon.activeSelf)
        {
            updateAmmoText();
        }

    }

    public bool Handle_Shooting()
    {
        //check if there is a weapon in hand
        if(currWeapon != null && currWeapon.activeSelf)
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

    public void UpdateObserver()
    {
        Handle_Shooting();
    }
}
