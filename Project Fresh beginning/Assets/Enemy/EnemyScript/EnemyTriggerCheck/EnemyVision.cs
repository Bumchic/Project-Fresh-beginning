using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    /*   [field:SerializeField] public GameObject GruntGameObject {  get; set;}
       public Grunt Grunt { get; set; }
       private void Awake()
       {
           Grunt = GruntGameObject.GetComponentInChildren<Grunt>();
       }

       void OnTriggerEnter2D(Collider2D other)
       {
           Debug.Log(other.gameObject);
           if(other.gameObject.tag == "Player")
           {
               Debug.Log("Chase");
               Grunt.isChasingPlayer = true;
           }
       }*/

    [field: SerializeField] public GameObject GruntGameObject { get; set; }
    public EnemyBaseScript Grunt { get; set; }

    private void Awake()
    {
        Grunt = GruntGameObject.GetComponent<EnemyBaseScript>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player detected. Start chasing!");
            Grunt.isChasingPlayer = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("Player out of range. Stop chasing.");
            Grunt.isChasingPlayer = false;
        }
    }

}
