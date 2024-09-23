using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComboAttack : MonoBehaviour
{
    Animator ani;
    bool strigger;
    public int combo;
    public int combonumber;
    public bool attacking;
    public float combotiming;
    public float combtempo;
    public float comboTransitionDelay;
    private float comboTransitionTimer; 

    void Start()
    {
        ani = GetComponent<Animator>();
        combo = 1;
        combotiming = 0.5f;
        combtempo = combotiming;
        combonumber = 3;
        comboTransitionDelay = 0.2f; // Set a default value for transition delay
        comboTransitionTimer = 0f; // Initialize the timer
    }

    // Update is called once per frame
    void Update()
    {
        HandleComboAttack(); // Call combo handling function in Update
    }

    public void HandleComboAttack() // Method to handle combo attack logic
    {
        combtempo -= Time.deltaTime;
        comboTransitionTimer -= Time.deltaTime; // Decrease transition timer

        // Start combo when pressing "J" and combtempo < 0
        if (Input.GetKeyDown(KeyCode.J) && combtempo < 0 && comboTransitionTimer <= 0)
        {
            attacking = true;
            ani.SetTrigger("Attack" + combo);
            combtempo = combotiming;
            comboTransitionTimer = comboTransitionDelay; // Reset the transition timer
        }
        // Continue combo if within the allowed time frame
        else if (Input.GetKeyDown(KeyCode.J) && combtempo > 0 && combtempo < 0.3f && comboTransitionTimer <= 0)
        {
            attacking = true;
            combo++;

            // Reset combo if exceeding allowed combo number
            if (combo > combonumber)
            {
                combo = 1;
            }

            ani.SetTrigger("Attack" + combo);
            combtempo = combotiming;
            comboTransitionTimer = comboTransitionDelay; // Reset the transition timer
        }
        // Reset attack and combo if input is not detected within allowed time
        else if (combtempo < 0 && !Input.GetKeyDown(KeyCode.J))
        {
            attacking = false;
            if (combtempo < 0)
                combo = 1;
        }
    }
}
