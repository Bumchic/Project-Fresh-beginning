using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int attackDamage; // dame by enemies
    public Player_Health playerHealth;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //dame to player
            GameManager.gameManager.enemyHealth.takeDamage(attackDamage);
        }
    }
}
        