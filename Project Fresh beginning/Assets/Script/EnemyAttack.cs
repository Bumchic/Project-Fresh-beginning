using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage = 10; // dame by enemies

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //dame to player
            GameManager.gameManager.EnemyHealth.TakeDamage(attackDamage);
        }
    }
}
        