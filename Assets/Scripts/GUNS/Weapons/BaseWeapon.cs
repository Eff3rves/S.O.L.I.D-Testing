using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    protected float fireRate;
    protected float cooldown;
    [SerializeField]
    protected AmmoManager ammoManager;

    protected LoadOutManager loadOut;
    public abstract bool Shoot();


}
