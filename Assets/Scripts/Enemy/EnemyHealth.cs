using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField] private int _currentHealth;
    private bool _once;

    public int Health
    {
        get { return EnemyController.Instance.Enemy.Health; }
        private set { EnemyController.Instance.Enemy.Health = value; }
    }

    public int CurrentHealth
    {
        get { return _currentHealth; }
        private set { _currentHealth = value; }
    }

    private void Update()
    {
        if (!_once)
        {
            _once = true;
            CurrentHealth = Health;
        }
    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        if (CurrentHealth <= 0)
        {
            CurrentHealth = 0;
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy die!");
    }
}
