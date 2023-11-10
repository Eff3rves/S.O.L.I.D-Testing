using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Factory
{
    public class ConcreteFactoryExplosion : Factory
    {
        //needs an override since it is inheriting from Factory
        // used to create a Prefab
        [SerializeField] private ProductExplosion productPrefab;

        public override IProduct GetProduct(Vector3 position)
        {
            // create a Prefab instance and get the product component
            GameObject instance = Instantiate(productPrefab.gameObject, position, Quaternion.identity);
            ProductExplosion newProduct = instance.GetComponent<ProductExplosion>();

            // each product contains its own logic
            newProduct.Initialize();

            return newProduct;
        }
    }
}

