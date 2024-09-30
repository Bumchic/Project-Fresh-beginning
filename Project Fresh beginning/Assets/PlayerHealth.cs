using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    void Start()
    {
        // Set the current health to max health at the start
        currentHealth = maxHealth;
    }

    // Call this function to deal damage to the player
    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;

        // Check if health falls below or equals 0, then reload the scene
        if (currentHealth <= 0)
        {
            Debug.Log("Player died!");
            SceneManager.LoadScene("SampleScene"); // Replace with your actual scene name
        }
    }

    // Optionally, add a method to heal the player
    public void Heal(int healAmount)
    {
        currentHealth += healAmount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
}
