using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Recoils : MonoBehaviour
{
    [SerializeField]
    protected float recoilStrength;
    [SerializeField]
    protected float recoilDuration;
    public abstract void recoil();

}
