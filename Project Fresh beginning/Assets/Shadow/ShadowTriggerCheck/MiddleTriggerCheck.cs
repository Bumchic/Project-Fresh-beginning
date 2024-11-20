using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiddleTriggerCheck : MonoBehaviour
{
    public GameObject MainCharacter { get; set; }
    public BoxCollider2D Collider { get; set; }
    public ShadowBase shadow { get; set; }

    void Awake()
    {
        MainCharacter = GameObject.FindGameObjectWithTag("Player");
        Collider = MainCharacter.GetComponentInChildren<BoxCollider2D>();
        shadow = GetComponentInParent<Shadow>();
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other == Collider)
        {
            shadow.InZoneMiddle = true;
        }
    }
}
