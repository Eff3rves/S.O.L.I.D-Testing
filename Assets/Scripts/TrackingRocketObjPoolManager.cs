using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;

public class TrackingRocketObjPoolManager : ObjPoolManager
{
    // Singleton instance of the RocketObjPoolManager
    private static TrackingRocketObjPoolManager instance;
    public static TrackingRocketObjPoolManager Instance => instance;

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
