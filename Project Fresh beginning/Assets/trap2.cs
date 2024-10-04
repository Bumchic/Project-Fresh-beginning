using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trap2 : MonoBehaviour
{
    private const float slowDuration = 2f; // How long the slowdown lasts
    private const float slowAmount = 0.5f; // Percentage of speed reduction (0.5 = 50% slower)
    private bool playerHit = false; // To track if the trap has already dealt damage

    void Start()
    {
        // No movement or rotation, as requested
    }

    void Update()
    {
        // Nothing needed in Update since movement and rotation are removed
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        // Check if the collided object has a PlayerHealth component
        PlayerHealth playerHealth = collider.gameObject.GetComponent<PlayerHealth>();
        if (playerHealth != null && !playerHit)
        {
            // Deal damage once
            playerHealth.TakeDamage(10);

            // Apply slow effect if the player has a movement script
            Movement_script playerMovement = collider.gameObject.GetComponent<Movement_script>();
            if (playerMovement != null)
            {
                StartCoroutine(SlowPlayer(playerMovement));
            }

            // Mark that the player has been hit to prevent multiple hits
            playerHit = true;
        }
    }

    // Reset the damage capability when the player leaves the trap's trigger
    private void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.gameObject.GetComponent<PlayerHealth>() != null)
        {
            playerHit = false;
        }
    }

    // Coroutine to slow the player down temporarily
    IEnumerator SlowPlayer(Movement_script playerMovement)
    {
        // Store the original speed
        float originalSpeed = playerMovement.Speed;

        // Reduce the player's speed
        playerMovement.Speed *= slowAmount;

        // Wait for the slow effect duration
        yield return new WaitForSeconds(slowDuration);

        // Restore the original speed
        playerMovement.Speed = originalSpeed;
    }
}
