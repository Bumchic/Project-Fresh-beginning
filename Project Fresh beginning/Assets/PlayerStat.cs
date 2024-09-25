using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerStat : MonoBehaviour
{
    // Declare variables inside the class
    [SerializeField] private int maxHealth;
    private int curentHealth;

    // Reference to the health bar UI component
    public HealthBar healthBar;

    // Event triggered when the player dies
    public UnityEvent OnDeath;

    private void OnEnable()
    {
        // Add a listener to the death event
        OnDeath.AddListener(Death);
    }

    private void OnDisable()
    {
        // Remove listener to prevent errors when the object is disabled
        OnDeath.RemoveListener(Death);
    }

    private void Start()
    {
        // Correctly reference PlayerHealth from GameManager
        curentHealth = GameManager.gameManager.PlayerHealth.currentHealth;
        maxHealth = GameManager.gameManager.PlayerHealth.maxHealth;

        healthBar.UpdateBar(curentHealth, maxHealth);
    }


    public void TakeDamage(int damage)
    {
        // Decrease health and update UI
        curentHealth -= damage;

        if (curentHealth <= 0)
        {
            curentHealth = 0;
            OnDeath.Invoke(); // Trigger the death event
        }

        healthBar.UpdateBar(curentHealth, maxHealth);
    }

    public void Heal(int healAmount)
    {
        // Increase health and update UI
        curentHealth += healAmount;

        if (curentHealth > maxHealth)
        {
            curentHealth = maxHealth;
        }

        healthBar.UpdateBar(curentHealth, maxHealth);
    }

    private void Death()
    {
        // Destroy the player object on death
        Destroy(gameObject);
        // Trigger game over functionality (e.g., return to menu)
        GameOver.LoadMainMenu();
    }

    private void Update()
    {
        // Press '9' to take damage
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            TakeDamage(10);
            Debug.Log("Current Health: " + curentHealth);
        }

        // Press '0' to heal
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Heal(10);
            Debug.Log("Current Health: " + curentHealth);
        }

        // Check if the player is dead
        GameOverCheck();
    }

    private void GameOverCheck()
    {
        // Check if health is 0 or below and trigger game over
        if (curentHealth <= 0)
        {
            GameOver.LoadMainMenu();
        }
    }
}
