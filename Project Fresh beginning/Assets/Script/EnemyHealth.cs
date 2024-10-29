using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 50; 
    public int currentHealth;
    public Sprite portrait; // Create a box to store the enemy's portrait
                            // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // Enemy's currentHealth goes down by the 
    // amount of damage that is dealt
    public void takeDamage(int dameAmount)
    {
        currentHealth -= dameAmount;
        if(currentHealth < 0)
        {
            Destroy(gameObject); // makes sure the enemy is destroyes if its health reaches 0
        }
    }

}
