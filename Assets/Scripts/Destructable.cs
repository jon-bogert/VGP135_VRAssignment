using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] float health = 30f;

    public void Damage(float amt)
    {
        health -= amt;
        if (health <= 0f)
            Death();
    }

    void Death()
    {
        Destroy(gameObject);
    }
}
