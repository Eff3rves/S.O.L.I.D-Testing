using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;

public class AKObjPoolManager : ObjPoolManager
{

    // Singleton instance of the AKObjPoolManager
    private static AKObjPoolManager instance;
    public static AKObjPoolManager Instance => instance;


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


    public PooledObject GetPooledObject()
    {
        if (OP != null)
            return OP.GetPooledObject();
        return null;
    }
}
