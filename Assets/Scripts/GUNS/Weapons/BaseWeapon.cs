using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    protected float fireRate;
    protected float cooldown;
    [SerializeField]
    protected AmmoManager ammoManager;
    public abstract bool Shoot();

}
