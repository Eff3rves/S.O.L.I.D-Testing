using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    public GameObject bulletPrefab;
    protected float fireRate;
    protected float cooldown;
    public abstract void Shoot();



}
