using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.ObjectPool;

public abstract class ObjPoolManager : MonoBehaviour
{
    [SerializeField]
    protected ObjectPool OP;

    [SerializeField]
    protected LoadOutManager loadOutManager;

    protected List<GameObject> weaponList;

    protected int Listcount;

    protected void Start()
    {
        weaponList = loadOutManager.weaponList;
        Listcount = weaponList.Count;
    }

}
