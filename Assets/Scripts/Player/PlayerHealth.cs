using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int Health
    {
        get { return PlayerController.Instance.Player.Health; }
        private set
        {
            PlayerController.Instance.Player.Health = value;
            UIManager.Instance.UIPlayer.SetMaxHealth(value);
        }
    }
    public int CurrentHealth
    {
        get { return PlayerController.Instance.Player.CurrentHealth; }
        private set
        {
            PlayerController.Instance.Player.CurrentHealth = value;
            UIManager.Instance.UIPlayer.SetCurrentHealth(value);
        }
    }

    private void Start()
    {
        SetHealth();
    }

    private void SetHealth()
    {
        UIManager.Instance.UIPlayer.SetMaxHealth(Health);
        UIManager.Instance.UIPlayer.SetCurrentHealth(CurrentHealth);
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
        Debug.Log("Player is dead.....");
    }
}
