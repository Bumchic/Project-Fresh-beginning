using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager;

    public Health_System PlayerHealth;

    private void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
            DontDestroyOnLoad(gameObject); // Keep the GameManager alive between scenes
        }
        else
        {
            Destroy(gameObject);
        }

        // Initialize PlayerHealth with 100 max health, for example
        PlayerHealth = new Health_System(100);
    }
}

