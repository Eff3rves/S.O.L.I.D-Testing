using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//uses design Pattern factory
namespace DesignPatterns.Factory
{
public class ProductExplosion : MonoBehaviour, IProduct
{
        //since this IProduct has abstract functions, it needs those functions in the other products
        [SerializeField] private string productName = "Explosion";

        public string ProductName { get => productName; set => productName = value; }
        private new ParticleSystem particleSystem;

        public void Initialize()
        {
            // any unique logic to this product
            gameObject.name = productName;
            particleSystem = GetComponent<ParticleSystem>();
            particleSystem.Stop();
            particleSystem.Play();
            Destroy(gameObject,particleSystem.main.duration);

            
        }
}
}