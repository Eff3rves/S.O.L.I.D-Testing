using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CameraShake : MonoBehaviour,IObserver
{
    [SerializeField]
    protected float duration;
    public abstract void Shake() ;

    public void UpdateObserver()
    {
        Shake();
    }
}
