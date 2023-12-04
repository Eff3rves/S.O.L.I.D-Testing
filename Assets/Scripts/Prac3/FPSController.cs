using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour,ISubject
{
    //handles the observers for each weapon
    private List<IObserver> observers = new List<IObserver>();

    // Singleton instance of the AKObjPoolManager
    private static FPSController instance;
    public static FPSController Instance => instance;


    private void Awake()
    {
        // Ensure there's only one instance of AKObjPoolManager in the scene
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate instances
        }
        else
        {
            instance = this;
            //DontDestroyOnLoad(gameObject); // Preserve across scene changes
        }
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

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        foreach (var observer in GetComponents<IObserver>())
        {
            RegisterObserver(observer);
        }
    }

    private void Update()
    {
        //Camera.main.transform.rotation = gameObject.transform.rotation;

        NotifyObservers();
    }

}
