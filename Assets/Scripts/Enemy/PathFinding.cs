using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinding
{
    [SerializeField]
    private Vector3 gridPos;
    private Vector3 cellCenter;
    private Vector3 cellSize;

    private List<Node> openList;
    private NodeGrid grid;

    public PathFinding() { }
    public PathFinding(int width, int height) 
    { 
        grid = new NodeGrid(width, height); 
    }

    private void Pathfinding(Vector3 start, Vector3 end)
    {
        openList.Add(new Node(start));

    }

    private bool CheckColisions(Vector3 pos)
    {
        cellCenter = pos + cellSize * 0.5f;
        Collider[] collider = Physics.OverlapBox(cellCenter, cellSize * 0.5f);

        foreach (var coll in collider)
        {
            if (coll.tag != "Enemy" || coll.tag != "Ground")
            {
                return true;
            }
        }

        return false;
    }

    //private void OnDrawGizmos()
    //{
    //    Vector3 cellCeter = gridPos + cellSize * 0.5f;
    //    cellSize.y = 0.0f;
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawWireCube(cellCeter, cellSize);
    //}
}

public class Node
{
    public Node(Vector3 pos) { value = pos; opened = false; }

    public Vector3 value;
    public bool opened;
    public Node parent;
}

public class NodeGrid
{
    int _width, _height;
    Node[] _data;

    bool CheckBounds(int x, int y)
    {
        return (x * y < _width * _height);
    }
    public NodeGrid(int width, int height)
    {
        _data = new Node[width * height];
        _width = width;
        _height = height;
    }

    public NodeGrid()
    {
        _width = 0;
        _height = 0;
        _data = null;
    }

    public Node Get(int x, int y)
    {
        if (!CheckBounds(x, y))
            return null;

        return _data[y * _width + x];
    }
    public Node Get(int index)
    {
        if (index >= _data.Length)
            return null;

        return _data[index];
    }

    public void Set(int x, int y, Node data)
    {
        if (!CheckBounds(x, y))
            return;

        _data[y * _width + x] = data;
    }
    public void Set(int index, Node data)
    {
        if (index >= _data.Length)
            return;

        _data[index] = data;
    }

}
