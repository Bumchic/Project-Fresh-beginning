using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class EnemyBaseScript : MonoBehaviour
{
    [field:SerializeField]public Rigidbody2D rigidbody { get; set ; }
    public EnemyStateMachine stateMachine { get; set; }
    public PatrolState patrolState { get; set; }

    [field: SerializeField] public BoxCollider2D WalkIntoWallCheck {  get; set; }
    [field: SerializeField] public float acceleration { get; set; } = 3f;
    [field: SerializeField] public Transform HeadTransform { get; set; }
    [field: SerializeField] public Boolean WalkingIntoWall {  get; set; }
    [field: SerializeField] public LayerMask FloorMask { get; set; }
    [field: SerializeField] public int isFacingRight { get; set; } 
    public float Transformx { get; set; }
    void Awake()
    {
        stateMachine = new EnemyStateMachine();
        patrolState = new PatrolState(this, stateMachine);
        Transformx = transform.localScale.x;
        isFacingRight = 0;
    }

    void Start()
    {
        stateMachine.Initialize(patrolState);
    }

    void Update()
    {
        stateMachine.enemyState.FrameUpdate();
        HitWallCheck();
    }

    void FixedUpdate()
    {
        stateMachine.enemyState.PhysicUpdate();
    }

    public void Move(float speed)
    {
        //float CurrentSpeed = Mathf.Clamp(((rigidbody.velocity.x + acceleration)*NumFaceDirection())*Time.deltaTime, -speed, +speed);

        //rigidbody.velocity = new Vector2(NumFaceDirection(), rigidbody.velocity.y);
        FaceDirection();
    }
    public void FaceDirection()
    {
        //float Direction = Mathf.Sign(rigidbody.velocity.x);
        transform.localScale = new Vector3(NumFaceDirection() * Transformx, transform.localScale.y, transform.localScale.z);
    }

    public void HitWallCheck()
    {
        WalkingIntoWall = Physics2D.OverlapAreaAll(WalkIntoWallCheck.bounds.min, WalkIntoWallCheck.bounds.max, FloorMask).Length > 0;
    }

    public int NumFaceDirection()
    {
        if(isFacingRight == 0)
        {
            return -1;
        }
        return 1;
    }
    
}
