using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float maxHealth;
    private float health;

    private void Start()
    {
        health = maxHealth;
    }

    public float Get()
    {
        return health;
    }

    public float Damage(float amt)
    {
        health -= amt;
        return health;
    }

    public void Reset()
    {
        health = maxHealth;
    }
}
