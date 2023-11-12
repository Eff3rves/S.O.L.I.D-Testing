using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponHandler : MonoBehaviour,ISubject
{
    [SerializeField]
    private Recoils recoils;

    [SerializeField]
    private MuzzleFlash flash;

    [SerializeField]
    private CameraShake shake;



    //handles the observers for each weapon
    private List<IObserver> observers = new List<IObserver>();

    private void Start()
    {
        RegisterObserver(recoils);
        RegisterObserver(flash);
        RegisterObserver(shake);
    }

    public void NotifyObservers()
    {
        foreach (var observer in observers)
        {
            observer.UpdateObserver();
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        observers.Add(observer);
    }

    public void RemoveObserver(IObserver observer)
    {
        observers.Remove(observer);
    }
}
