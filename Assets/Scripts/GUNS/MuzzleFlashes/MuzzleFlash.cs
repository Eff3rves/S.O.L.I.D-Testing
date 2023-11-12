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

    public ConcreteFactoryMuzzleFlash muzzleFlash; //make the muzzle flash

    private Vector3 bulletDire; //determines where the muzzle is going

    private void Update()
    {
        bulletDire = Vector3.Normalize(Forward.position - gameObject.transform.position);

    }

    public void Flash()
    {
        muzzleFlash.dire = bulletDire;
        muzzleFlash.GetProduct(BulletSpawn.position);
    }

    public void UpdateObserver()
    {
        Flash();
    }
}
