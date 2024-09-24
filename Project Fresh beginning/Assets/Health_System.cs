using System.Collections;

using System.Collections.Generic;

using UnityEngine;

public class Health_System
{
    public int currentHealth;
    public int maxHealth;

    public Health_System(int maxHealth)
    {
        this.maxHealth = maxHealth;
        this.currentHealth = maxHealth; // Start with full health
    }

    // Add methods to handle health changes if needed
}
