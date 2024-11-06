using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;
using static UnityEngine.EventSystems.EventTrigger;

public class EnemyBaseScript : MonoBehaviour
{
    [field:SerializeField]public Rigidbody2D rigidbody { get; set ; }
    public EnemyStateMachine stateMachine { get; set; }
    public PatrolState patrolState { get; set; }
    [field: SerializeField] public BoxCollider2D WalkIntoWallCheck {  get; set; }
    [field: SerializeField] public Boolean WalkingIntoWall {  get; set; }
    [field: SerializeField] public LayerMask FloorMask { get; set; }
    [field: SerializeField] public int isFacingRight { get; set; } 
    public float Transformx { get; set; }
    public float maxSpeed { get; set; } = 5f;
    [field: SerializeField] public Boolean isChasingPlayer {  get; set; }
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
        FaceDirection();
    }

    void Update()
    {
        stateMachine.enemyState.FrameUpdate();
        FaceDirection();
       
     
    }

    void FixedUpdate()
    {
        stateMachine.enemyState.PhysicUpdate();
    }

    public void Move(float speed)
    {
        rigidbody.velocity = new Vector2(speed * NumFaceDirection(), rigidbody.velocity.y);
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

    public float NumFaceDirection()
    {
        if(isFacingRight == 0)
        {
            return -1f;
        }
            return 1f;
    }


}
