using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_System
{
    [field: SerializeField]private float _CurrentHealth;
    private float _MaxHealth;


    public float currentHealth
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

    public float MaxHealth
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

    public Health_System(float CurrentHealth, float MaxHealth)
    {
        _CurrentHealth = CurrentHealth;
        _MaxHealth = MaxHealth;
    }
    
    public void TakeDamage(float DamageAmount)
    {
        if(_CurrentHealth > 0)
        {
            _CurrentHealth -= DamageAmount;
        }
    }

    public void Heal(float HealAmount)
    {
        _CurrentHealth += HealAmount;
        if(_CurrentHealth > _MaxHealth)
        {
            _CurrentHealth = _MaxHealth;
        }
    }

}
