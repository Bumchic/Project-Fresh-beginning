using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyBaseScript : MonoBehaviour
{
    [field:SerializeField]public Rigidbody2D rigidbody { get; set ; }
    public EnemyStateMachine stateMachine { get; set; }

    public float acceleration { get; set; } = 1f;
    [field: SerializeField] public Transform HeadTransform { get; set; }
    void Awake()
    {
        stateMachine = new EnemyStateMachine();
    }
    public void Move(float speed)
    {


        float CurrentSpeed = Mathf.Clamp(rigidbody.velocity.x + acceleration, -speed, +speed);

        rigidbody.velocity = new Vector2(CurrentSpeed, rigidbody.velocity.y);
        FaceDirection();
    }
    public void FaceDirection()
    {

    }
}
