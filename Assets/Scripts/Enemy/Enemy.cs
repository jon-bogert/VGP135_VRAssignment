using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    public Health health;

    private void Awake()
    {
        health = new Health(10);
    }
}
