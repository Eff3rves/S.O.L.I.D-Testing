using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fire : MonoBehaviour
{
    //this should be slit to 2 functions 1 for bullet type and 1 for bullet

    [SerializeField]
    List<GameObject> gameObjects;

    [SerializeField]
    float fireForce;
    public GameObject selectedProjectile;
    // Start is called before the first frame update
    void Start()
    {
        selectedProjectile = gameObjects[gameObjects.Count - 1];
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.mouseScrollDelta.y < 0)
        {
            if (selectedProjectile == gameObjects[-1])
            {
                selectedProjectile = gameObjects[0];
            }
        }
        else if (Input.mouseScrollDelta.y > 0)
        {
            if (selectedProjectile == gameObjects[0])
            {
                selectedProjectile = gameObjects[-1];
            }
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Fired();
        }
    }

    private void Fired()
    {
        //Debug.Log("fired");
        selectedProjectile.SetActive(true);
        selectedProjectile.transform.position = Camera.main.transform.position;
        selectedProjectile.transform.position += new Vector3(0, 0.5f, 0);
        selectedProjectile.GetComponent<Rigidbody>().AddForce(Camera.main.transform.forward * fireForce, ForceMode.Impulse);
    }
}
