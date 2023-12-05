using DesignPatterns.Factory;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductHit : MonoBehaviour, IProduct
{
    //since this IProduct has abstract functions, it needs those functions in the other products
    [SerializeField] private string productName = "HitEffect";

    public string ProductName { get => productName; set => productName = value; }
    private new ParticleSystem particleSystem;

    public void Initialize()
    {
        // any unique logic to this product
        gameObject.name = productName;
        particleSystem = GetComponent<ParticleSystem>();
        particleSystem.Stop();
        particleSystem.Play();
        Destroy(gameObject, particleSystem.main.duration);


    }
}
