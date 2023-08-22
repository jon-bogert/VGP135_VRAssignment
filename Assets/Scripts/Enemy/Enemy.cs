using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Grid grid;
    [SerializeField]
    private Vector2 pos;
    public Health health;

    private void Awake()
    {
        health = new Health(10);
    }

    private void Start()
    {
        transform.position = grid.LocalToWorld(pos);
    }

    private void Update()
    {

    }

    private void Pathfinding()
    {

    }
}
