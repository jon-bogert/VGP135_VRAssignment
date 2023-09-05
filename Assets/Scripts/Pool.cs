using System;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Interface for Objects being added to XephTools.Pool<T>.
/// Reset() called when getting next item in pool
/// </summary>
public interface IPoolable
{
    public void Reset();
}

/// <summary>
/// Object pool pattern
/// </summary>
[Serializable]
public class Pool<T> : MonoBehaviour where T : MonoBehaviour, IPoolable
{
    protected List<T> objects;
    protected int nextIndex;

    public int Size
    {
        get { return objects.Count; }
    }

    public List<T> Objects
    {
        get { return objects; }
    }

    public Pool(List<T> objects)
    {
        Resize(objects);
    }

    public T GetNext()
    {
        T nextObject = objects[nextIndex];
        nextIndex = (nextIndex + 1) % objects.Count;
        nextObject.Reset();
        return nextObject;
    }

    //Calls IPoolable on all objects and set to 0;
    public void OnReset()
    {
        for (int i = 0; i < objects.Count; i++)
        {
            objects[i].Reset();
        }
        nextIndex = 0;
    }

    //Resizes the pool to new list of objects
    public void Resize(List<T> objects)
    {
        this.objects = objects;
        nextIndex = 0;
    }
}
