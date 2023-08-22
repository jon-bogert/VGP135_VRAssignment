using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health
{
    private float health;
    
    public Health(float maxHealth)
    {
        health = maxHealth;
    }

    public float GetHealth()
    {
        return health;
    }

    public float Damage(float amt)
    {
        health -= amt;
        return health;
    }
}
