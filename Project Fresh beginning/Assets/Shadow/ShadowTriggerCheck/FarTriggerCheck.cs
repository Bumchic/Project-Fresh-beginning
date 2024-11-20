using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarTriggerCheck : MonoBehaviour

{
    public GameObject MainCharacter { get; set; }
    public BoxCollider2D Collider { get; set; } 
    public ShadowBase shadow { get ; set; }

    void Awake()
    {
        //MainCharacter = GameObject.FindWithTag("Player");
        //Collider = MainCharacter.GetComponentInChildren<BoxCollider2D>();
        shadow = GetComponentInParent<Shadow>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("far");
            shadow.InZoneFar = true;
        }
    }

}
