using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;
using DesignPatterns.Factory;

public abstract class Projectile : MonoBehaviour
{
    [SerializeField]
    protected float damage;

    protected float countdown;
    

}
