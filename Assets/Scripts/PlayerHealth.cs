using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    public UnityEvent deathEvent;

    [Space, SerializeField]
    private int _health = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        if(_health <= 0)
        {
            deathEvent.Invoke();
        }
    }

    public int Damage(int amt)
    {
        return _health -= amt;
    }
}
