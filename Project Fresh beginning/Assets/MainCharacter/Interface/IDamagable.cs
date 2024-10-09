using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamagable
{
    float CurrentHealth { get; set; }

    float MaxHealth{get; set;}

    void Heal(float HealAmount);

    void Die();
    void TakeDamage(float Damage);
    
}
