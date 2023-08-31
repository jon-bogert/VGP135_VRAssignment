using UnityEngine;

public class Enemy: MonoBehaviour
{
    public Health health;

    public Enemy()
    {
        health = new Health(10);
    }
}
