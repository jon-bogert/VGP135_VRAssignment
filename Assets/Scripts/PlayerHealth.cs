using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    GameManager _gameManager;
    [SerializeField] int _health = 0;
    HealthBar _healthBar;

    private void Start()
    {
        _healthBar = FindObjectOfType<HealthBar>();
        _healthBar.SetValue(_health);
        _gameManager = GameManager.instance;
        _gameManager.ScoreReset();
    }

    public int Damage(int amt)
    {
        _health -= amt;
        _healthBar.SetValue(_health);
        if (_health <= 0)
        {
            _gameManager.GameOver();
        }
        return _health;
    }

    public void Heal()
    {
        _health = 100;
        _healthBar.SetValue(_health);
    }
}
