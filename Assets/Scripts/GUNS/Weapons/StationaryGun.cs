using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;
using TMPro;

public class StationaryGun : BaseWeapon
{
    private AKObjPoolManager aKObjPoolManager;

    [SerializeField]
    private Transform Forward;

    [SerializeField]
    private Transform BulletSpawn;

    [SerializeField]
    private GameObject TurretHead;

    [SerializeField]
    private Transform location;

    private TMP_Text ammoText;

    private TMP_Text interectText;

    public bool inUse;

    private GameObject player;

    bool btnDown = false;

    bool fired = false;

    private Vector3 startLocation;

    public float mouseSensitivity = 2.0f;

    private float verticalRotation = 0f;
    private float horizontalRotation = 0f;

    private FPSController fPSController;
    private HandleCamera handleCamera;
    public override bool Shoot()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            btnDown = true;
        }
        if (Input.GetButtonUp("Fire1"))
        {
            btnDown = false;
        }

        return fired;
    }

    // Start is called before the first frame update
    void Start()
    {
        fireRate = 0.05f;
        cooldown = 0;
        aKObjPoolManager = AKObjPoolManager.Instance;
        loadOut = LoadOutManager.Instance;
        inUse = false;

        ammoText = GameObject.Find("Ammotext").GetComponent<TMP_Text>();
        interectText = GameObject.Find("InterectNotice").GetComponent<TMP_Text>();

        player = GameObject.FindGameObjectWithTag("Player");
        startLocation = location.position;

        fPSController = FPSController.Instance;
        handleCamera = HandleCamera.Instance;

    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(player.transform.position,location.position) > 5) {
            interectText.text = " ";
        }

        if (inUse)
        {
            fPSController.RemoveObserver(handleCamera);

            float axisX = Input.GetAxis("Mouse X");
            float axisY = Input.GetAxis("Mouse Y");
            horizontalRotation += axisX * mouseSensitivity;
            verticalRotation -= axisY * mouseSensitivity;
            verticalRotation = Mathf.Clamp(verticalRotation, -30, 30);
            horizontalRotation = Mathf.Clamp(horizontalRotation, -90, 90);

            TurretHead.transform.rotation = Quaternion.Euler(verticalRotation, horizontalRotation, 0);

            Camera.main.transform.rotation = TurretHead.transform.rotation;

            player.transform.position = new Vector3(location.position.x, startLocation.y, location.position.z) ;

            if (loadOut.getCurrWeapon() != null)
            {
                loadOut.getCurrWeapon().SetActive(false);
            }

            cooldown += Time.deltaTime;
            fired = false;
            if (btnDown && ammoManager.cankeepShooting())
            {

                if (fireRate < cooldown)
                {
                    //Debug.Log("Fired");
                    cooldown = 0;

                    Vector3 bulletDire = Vector3.Normalize(BulletSpawn.position - Forward.position);
                    GameObject bull = aKObjPoolManager.GetPooledObject().gameObject;


                    bull.transform.position = BulletSpawn.position;
                    //Debug.Log(bull.transform.position);
                    bull.GetComponent<DefultBullet>().dire = bulletDire;

                    fired = true;
                }

            }
            else
            {
                fired = false;
            }

            //once the weapon is shot, start to notify every observer
            if (Shoot())
            {
                GetComponent<WeaponHandler>().NotifyObservers();
                //sets loadout to cannot switch
                loadOut.canSwitch = false;
                ammoManager.Shot();
            }



        }
        else
        {
            if (loadOut.getCurrWeapon() != null)
            {
                loadOut.getCurrWeapon().SetActive(true);
            }



        }

        if (ammoText != null)
        {
            updateAmmoText();
        }
        else Debug.Log("That is null");

    }

    private void updateAmmoText()
    {
        if (inUse)
        {

            ammoText.text = (ammoManager.ammoInClip + " / " + ammoManager.totalAmmo);
        }
        else
        {
            ammoText.text = " ";
        }

    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            interectText.text = "Press F to interact";

            if (Input.GetButtonDown("Interact"))
            {
                inUse = !inUse;
                if (!inUse) fPSController.RegisterObserver(handleCamera);
            }
        }
        if (inUse)
        {
            interectText.text = " ";
        }

    }
}
