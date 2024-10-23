using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private int _CurrentHealth;
    private int _MaxHealth = 100;

    void Start()
    {
        _CurrentHealth = _MaxHealth;
    }
    public int currentHealth
    {
        get
        {
            return _CurrentHealth;
        }
        set
        {
            _CurrentHealth = value;
        }
    }

    public int MaxHealth
    {
        get
        {
            return _MaxHealth;
        }
        set
        {
            _MaxHealth = value;
        }
    }

    public void Health_System(int CurrentHealth, int MaxHealth)
    {
        _CurrentHealth = CurrentHealth;
        _MaxHealth = MaxHealth;
    }

    public void TakeDamage(int DamageAmount) // damageAmount = how much dame the player takes
    {
        if (_CurrentHealth > 0)
        {
            _CurrentHealth -= DamageAmount;
        }
    }

    public void Heal(int HealAmount)
    {
        _CurrentHealth += HealAmount;
        if (_CurrentHealth > _MaxHealth)
        {
            _CurrentHealth = _MaxHealth;
        }
    }
}
