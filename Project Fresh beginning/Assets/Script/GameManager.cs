using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager gameManager { get; private set; }

    public Health_System PlayerHealth = new Health_System(100, 100);
    public GameObject shadow;
    public GameObject healthItemPrefab;
  
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
        Instantiate(healthItemPrefab, new Vector3(2f, 1f, 0f), Quaternion.identity);
        Instantiate(shadow, new Vector3(-5.44119978f, 0.633400023f, -0.0356026478f), Quaternion.identity);

    }
    private void Update()
    {
   
    }

}
