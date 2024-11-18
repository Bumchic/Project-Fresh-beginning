using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStat : MonoBehaviour
{
    public Health_System enemyHealth;
    void Start()
    {
        // Khởi tạo hp của enemy
        enemyHealth = new Health_System(50, 50);
    }

    void Update()
    {
        // Check hp của enemy <= 0 -> enemy die
        if (enemyHealth.currentHealth <= 0)
        {
            Die();
        }
    }
    // process when enemy die
    void Die()
    {
        Debug.Log("Enemy died!");
        Destroy(gameObject); // delete enemy
    }

    // gây dame  to enemies 
    public void TakeDamage(int damageAmount)
    {
        enemyHealth.TakeDamage(damageAmount);
        Debug.Log("Enemy health: " + enemyHealth.currentHealth);
    }
}
