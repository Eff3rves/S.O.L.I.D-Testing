using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultCrate : Crate, Destructable
{
    public void takeDmg(float damage)
    {
        OnDamaged(damage);
    }
}
