using DesignPatterns.ObjectPool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketObjPoolManager : ObjPoolManager
{

    // Singleton instance of the RocketObjPoolManager
    private static RocketObjPoolManager instance;
    public static RocketObjPoolManager Instance => instance;

    private void Awake()
    {
        // Ensure there's only one instance of RocketObjPoolManager in the scene
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
