using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStat : MonoBehaviour
{
 
    void Start()
    {
        
    }


    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Alpha0))
        {
            PlayerTakeDamage(10);
            Debug.Log(GameManager.gameManager.PlayerHealth.currentHealth);
        }

        if (Input.GetKeyDown(KeyCode.Alpha9))
            {
            PlayerHeal(10);
            Debug.Log(GameManager.gameManager.PlayerHealth.currentHealth);
        }
        Debug.Log(GameManager.gameManager.PlayerHealth.currentHealth);
        gameOver();
    }
    private void gameOver()
    {
        if (GameManager.gameManager.PlayerHealth.currentHealth <= 0)
        {
            GameOver.LoadMainMenu();
        }
    }
    private void PlayerTakeDamage(int DamageAmount)
    {
        GameManager.gameManager.PlayerHealth.TakeDamage(DamageAmount);       
    }

    

    private void PlayerHeal(int HealAmount)
    {
        GameManager.gameManager.PlayerHealth.Heal(HealAmount);

    }
}
