using DesignPatterns.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFactoryManager : FactoryManager
{
    [SerializeField]
    private ConcreteFactoryExplosion explosion;


    // Singleton instance of the AKObjPoolManager
    private static ExplosionFactoryManager instance;
    public static ExplosionFactoryManager Instance => instance;
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


    public ConcreteFactoryExplosion getFactory()
    {
        return explosion;
    }
}
