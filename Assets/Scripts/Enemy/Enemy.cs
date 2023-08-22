using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField]
    private float speed;
    [SerializeField]
    private Grid grid;
    public Health health;

    [SerializeField]
    private Vector3 pos;
    [SerializeField]
    private Vector3 gridPos;
    public bool temp;
    public Vector3 cellSize;

    private void Awake()
    {
        health = new Health(10);
    }

    private void Start()
    {
        cellSize = grid.cellSize;
        gridPos = pos;
    }

    private void Update()
    {
        transform.position = grid.LocalToWorld(pos);
        if (CheckColisions(gridPos))
        {
            Debug.Log("Access");
        }
    }

    private void Pathfinding()
    {
        
    }

    private bool CheckColisions(Vector3 pos)
    {
        Vector3 cellCenter = pos + cellSize * 0.5f;
        cellSize.y = 0.0f;
        Collider[] collider = Physics.OverlapBox(cellCenter, cellSize * 0.5f);

        foreach (var coll in collider)
        {
            if (coll.tag == "Player")
            {
                temp = true;
                return true;
            }
        }
        temp = false;
        return false;
    }

    private void OnDrawGizmos()
    {
        Vector3 cellCeter = gridPos + cellSize * 0.5f;
        cellSize.y = 0.0f;
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(cellCeter, cellSize);
    }
}
