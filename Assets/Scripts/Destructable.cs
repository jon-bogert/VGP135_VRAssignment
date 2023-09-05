using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] float health = 30f;

    float maxHealth;

    private void Awake()
    {
        maxHealth = health;
    }

    public void Damage(float amt)
    {
        health -= amt;
        if (health <= 0f)
            Death();
    }

    void Death()
    {
        Destroy(gameObject); // TODO - Change this to fit with Pooling
    }

    public void ResetHealth()
    {
        health = maxHealth;
    }
}
