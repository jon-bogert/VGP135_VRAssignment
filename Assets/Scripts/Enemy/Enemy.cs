using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Enemy : MonoBehaviour
{
    public Health health;

    private void Awake()
    {
        health = new Health(10);
    }

    private void Update()
    {

    }

}
