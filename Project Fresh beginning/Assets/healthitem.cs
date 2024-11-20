using UnityEngine;

public class HealthItem : MonoBehaviour
{
    public int healAmount = 20;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager.gameManager.PlayerHealth.Heal(healAmount);
            Destroy(gameObject);
        }
    }
}
