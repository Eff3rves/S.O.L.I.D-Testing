using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadOutManager : MonoBehaviour
{
    public List<GameObject> weaponList; 
    private int currentWeapon;

    // Singleton instance of the AKObjPoolManager
    private static LoadOutManager instance;
    public static LoadOutManager Instance => instance;

    private bool m_canSwitch;
    public bool canSwitch
    {
        get { return m_canSwitch; }
        set { m_canSwitch = value; }
    }

    int Listcount;

    private void Awake()
    {

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

    // Start is called before the first frame update
    void Start()
    {

        Listcount = weaponList.Count;

        //checks the weaponlist 
        for (currentWeapon = 0; currentWeapon < weaponList.Count - 1; currentWeapon++)
        {
            if(weaponList[currentWeapon] == null)
            {
                weaponList.Remove(weaponList[currentWeapon]);
            }

            if (weaponList[currentWeapon].gameObject.activeSelf)
            {
                break;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {

        if (weaponList.Count > 0)
        {
            if (Input.GetButtonDown("Drop"))
            {
                if (weaponList.Count > 0)
                {
                    weaponList.Remove(weaponList[currentWeapon]);
                }
                return;
            }

            if (Listcount > weaponList.Count)
            {
                currentWeapon = 0;
                weaponList[currentWeapon].SetActive(true);
                Listcount = weaponList.Count;
            }

            if (Listcount < weaponList.Count)
            {
                foreach (var weapon in weaponList)
                {
                    if (weapon != weaponList[currentWeapon] && weapon.activeSelf)
                    {
                        weapon.SetActive(false);
                    }
                }
                Listcount = weaponList.Count;
            }

            if (canSwitch)
            {
                SwitchWeapon();
            }
        }
  
    }

    //returns current weapon for player to use
    public GameObject getCurrWeapon()
    {
        if(weaponList.Count <= 0)
        {
            return null;
        }
        if(currentWeapon < weaponList.Count)
        {
            //Debug.Log(currentWeapon);
            GameObject weapon = weaponList[currentWeapon];
            return weapon;
        }

        return null;

    }

    public void addWeapon(GameObject newWeapon)
    {
        weaponList.Add(newWeapon);
    }

    //using scroll wheel to switch weapon
    private void SwitchWeapon()
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
