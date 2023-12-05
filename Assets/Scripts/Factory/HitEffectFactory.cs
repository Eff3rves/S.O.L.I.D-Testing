using DesignPatterns.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffectFactory : Factory
{
    //needs an override since it is inheriting from Factory
    // used to create a Prefab
    [SerializeField] private ProductHit productPrefab;

    public Vector3 dire;

    public override IProduct GetProduct(Vector3 position)
    {
        // create a Prefab instance and get the product component
        GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
        ProductMuzzleFlash newProduct = instance.GetComponent<ProductMuzzleFlash>();

        // each product contains its own logic
        newProduct.Initialize();
        newProduct.transform.rotation = Quaternion.LookRotation(dire, Vector3.up);
        return newProduct;
    }
}


