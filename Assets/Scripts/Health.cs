using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField]
    private float health;

    public float Get()
    {
        return health;
    }

    public float Damage(float amt)
    {
        health -= amt;
        return health;
    }

}
