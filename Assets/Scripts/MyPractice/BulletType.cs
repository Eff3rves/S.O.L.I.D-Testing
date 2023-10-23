using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletType : MonoBehaviour
{
    [SerializeField]
    List<GameObject> gameObjects;

    private GameObject selectedProjectile;

    private int bulletNum;
    public GameObject Projectile
    {
        get { return selectedProjectile; }
        set { selectedProjectile = value; }
    }

    private void Start()
    {
        bulletNum = 0;
        selectedProjectile = gameObjects[0];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y > 0)
        {
            if (selectedProjectile == gameObjects[gameObjects.Count-1])
            {
                bulletNum = 0;
                selectedProjectile = gameObjects[0];
                
            }
            else
            {
                bulletNum++;
                selectedProjectile = gameObjects[bulletNum];
            }
        }
        else if (Input.mouseScrollDelta.y < 0)
        {
            if (selectedProjectile == gameObjects[0])
            {
                selectedProjectile = gameObjects[gameObjects.Count - 1];
                bulletNum = gameObjects.Count - 1;
            }
            else
            {
                bulletNum--;
                selectedProjectile = gameObjects[bulletNum];
            }
        }
    }
}
