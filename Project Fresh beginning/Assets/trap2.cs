using System.Collections;
using UnityEngine;

public class trap2 : MonoBehaviour
{
    public float damageAmount = 1f; 
    private bool isPlayerInTrap = false; 
    private Coroutine damageCoroutine; 

    void OnCollisionEnter2D(Collision2D collision)
    {
       
        if (collision.gameObject.CompareTag("Player"))
        {
            //PlayerHealth playerHealth = collision.gameObject.GetComponent<PlayerHealth>();
            if (!isPlayerInTrap)
            {
                isPlayerInTrap = true;
                damageCoroutine = StartCoroutine(DamageOverTime());
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

    IEnumerator DamageOverTime()
    {
        while (isPlayerInTrap)
        {
            GameManager.gameManager.PlayerHealth.TakeDamage(damageAmount);
            yield return new WaitForSeconds(1f); 
        }
    }
}
