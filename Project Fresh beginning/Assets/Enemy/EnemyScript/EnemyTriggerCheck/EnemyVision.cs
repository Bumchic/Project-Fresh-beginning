using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [field:SerializeField] public GameObject GruntGameObject {  get; set;}
    public Grunt Grunt { get; set; }
    private void Awake()
    {
        Grunt = GruntGameObject.GetComponentInChildren<Grunt>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Grunt.isChasingPlayer = true;
        }
    }

}
