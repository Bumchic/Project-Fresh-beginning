﻿using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    
    public static GameManager gameManager { get; private set; }
    public EnemyHealth enemyHealth = new EnemyHealth();
    public Health_System PlayerHealth = new Health_System(100, 100);
    public GameObject shadow;
    public Boolean SpawnShadow;

    public void HandleDeath(GameObject gameObject)
    {
        if(gameObject.CompareTag("Player"))
        {
            OnPlayerDeath();
        }
    }

    public void OnPlayerDeath()
    {
        Debug.Log("Player died! Game Over!");
        // Dừng thời gian trong game
        Time.timeScale = 0;

     
    }


  
    void Awake()
    {
        if(gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
        gameManager = this; 
        }
    }
    void Start()
    {
        if(SpawnShadow)
        {
            Instantiate(shadow, new Vector3(-5.44119978f, 0.633400023f, -0.0356026478f), Quaternion.identity);          
        }

    }
    private void Update()
    {
   
    }

}
