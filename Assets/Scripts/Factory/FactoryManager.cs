using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns.Factory;

public class FactoryManager : MonoBehaviour
{

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
