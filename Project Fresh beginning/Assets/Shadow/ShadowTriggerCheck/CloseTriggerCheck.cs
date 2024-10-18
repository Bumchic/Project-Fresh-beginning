using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseTriggerCheck : MonoBehaviour
{
    public GameObject MainCharacter { get; set; }
    public Shadow shadow { get; set; }

    void Awake()
    {
        MainCharacter = GameObject.FindGameObjectWithTag("Player");
        shadow = GetComponentInParent<Shadow>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

}
