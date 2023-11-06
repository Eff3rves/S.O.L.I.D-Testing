using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseWeapon : MonoBehaviour
{
    protected float fireRate;
    protected float cooldown;
    public abstract bool Shoot();



}
