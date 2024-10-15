using UnityEngine;
using UnityEngine.SceneManagement; 

public class PlayerHealth : MonoBehaviour
{
    public float maxHealth = 100f; 
    public float health; 

    void Start()
    {
        health = maxHealth;
    }

    public void TakeDamage(float damage)
    {
      
        health -= damage;
        Debug.Log("Player bị sát thương: " + damage + " máu còn lại: " + health);

       
        if (health <= 0f)
        {
            Die();
        }
    }

    public void Heal(float healAmount)
    {
        health += healAmount;

        // Đảm bảo máu không vượt quá giới hạn tối đa
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        Debug.Log("Player được hồi máu: " + healAmount + " máu hiện tại: " + health);
    }

    void Die()
    {
        Debug.Log("Player đã chết!");
     
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }
}
