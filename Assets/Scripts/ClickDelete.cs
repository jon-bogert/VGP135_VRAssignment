using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDelete : MonoBehaviour
{
    [SerializeField]
    EnemyPool pool;
    bool canDelete = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && canDelete)
        {
            pool.KillEnemy();
            canDelete = false;
        }  
        else if (Input.GetKeyUp(KeyCode.Space))
        {
            canDelete = true;
        }
    }
}
