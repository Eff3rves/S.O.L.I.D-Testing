using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.Factory;
public class MuzzleFlash : MonoBehaviour,IObserver
{
    [SerializeField]
    private Transform Forward;

    [SerializeField]
    private Transform BulletSpawn; //find the gun tip for muzzle flash

    private MuzzleFlashFactoryManager muzzleFlash; //make the muzzle flash

    private Vector3 bulletDire; //determines where the muzzle is going

    private void Start()
    {
        muzzleFlash = MuzzleFlashFactoryManager.Instance;
    }

    private void Update()
    {
        bulletDire = Vector3.Normalize(Forward.position - gameObject.transform.position);

    }

    public void Flash()
    {
        muzzleFlash.getFactory().dire = bulletDire;
        muzzleFlash.getFactory().GetProduct(BulletSpawn.position);
    }

    public void UpdateObserver()
    {
        Flash();
    }
}
