using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] float health = 30f;

    float maxHealth;

    public bool isDead = false;

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
        isDead = true;
    }

    public void ResetHealth()
    {
        health = maxHealth;
        isDead = false;
    }
}
