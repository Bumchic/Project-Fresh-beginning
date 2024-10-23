using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    
    public static GameManager gameManager { get; private set; }


    public Health_System PlayerHealth = new Health_System(100, 100);
    public Health_System EnemyHealth = new Health_System(50, 50); 
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
}
