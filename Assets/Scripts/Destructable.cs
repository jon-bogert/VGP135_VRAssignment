using UnityEngine;

public class Destructable : MonoBehaviour
{
    [SerializeField] float health = 30f;
    [SerializeField] float maxHealth = 30f;

    public bool isDead = false;

    private void Start()
    {
        maxHealth = health;
    }

    public void Damage(float amt)
    {
        Debug.Log("Damage");
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
