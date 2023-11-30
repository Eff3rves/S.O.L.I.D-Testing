using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.Factory;

public class MuzzleFlashFactoryManager : FactoryManager
{
    [SerializeField]
    private ConcreteFactoryMuzzleFlash muzzleFlash;


    // Singleton instance of the AKObjPoolManager
    private static MuzzleFlashFactoryManager instance;
    public static MuzzleFlashFactoryManager Instance => instance;
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


    public ConcreteFactoryMuzzleFlash getFactory()
    {
        return muzzleFlash;
    }
}
