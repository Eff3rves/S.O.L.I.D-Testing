using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectManager : FactoryManager
{
    [SerializeField]
    private HitEffectFactory hitEffect;


    // Singleton instance of the AKObjPoolManager
    private static HitEffectManager instance;
    public static HitEffectManager Instance => instance;
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


    public HitEffectFactory getFactory()
    {
        return hitEffect;
    }
}
