using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour, IEnemyMoveable
{
    [field:SerializeField]public Rigidbody2D rigidbody { get; set ; }
    void Awake()
    {
        GetComponent<Renderer>().material.color = Color.red;
    }

    public void FaceDirection()
    {
       
    }

    public void Move()
    {
        
    }

    public void PathFind()
    {
       
    }
}
