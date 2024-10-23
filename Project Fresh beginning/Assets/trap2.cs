using System.Collections;
using UnityEngine;

public class trap2 : MonoBehaviour
{
    public int damageAmount = 1; 
    private bool isPlayerInTrap = false; 
    private Coroutine damageCoroutine; 

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (playerHealth != null && !isPlayerInTrap)
            {
                isPlayerInTrap = true;
                damageCoroutine = StartCoroutine(DamageOverTime(playerHealth));
            }
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player") && isPlayerInTrap)
        {
            isPlayerInTrap = false;
            if (damageCoroutine != null)
            {
                StopCoroutine(damageCoroutine);
            }
        }
    }

    IEnumerator DamageOverTime(PlayerHealth playerHealth)
    {
        while (isPlayerInTrap)
        {
            playerHealth.TakeDamage(damageAmount);
            yield return new WaitForSeconds(1); 
        }
    }
}
