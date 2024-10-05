using System.Collections;
using UnityEngine;

public class trap2 : MonoBehaviour
{
    public float damageAmount = 1f; // Damage to apply per second
    private bool isPlayerInTrap = false; // Track if player is in the trap
    private Coroutine damageCoroutine; // Reference to the running coroutine

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collided object has the tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null && !isPlayerInTrap)
            {
                // Start dealing continuous damage when the player enters the trap
                isPlayerInTrap = true;
                damageCoroutine = StartCoroutine(DamageOverTime(playerHealth));
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // Check if the player has exited the trap
        if (collision.gameObject.CompareTag("Player") && isPlayerInTrap)
        {
            // Stop dealing damage when the player leaves the trap
            isPlayerInTrap = false;
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
            }
        }
    }

    // Coroutine to apply damage over time
    IEnumerator DamageOverTime(PlayerHealth playerHealth)
    {
        while (isPlayerInTrap)
        {
            // Apply damage every second
            playerHealth.TakeDamage(damageAmount);
            yield return new WaitForSeconds(1f); // Wait 1 second before applying damage again
        }
    }
}
