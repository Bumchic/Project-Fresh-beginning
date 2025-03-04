using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

using static UnityEngine.EventSystems.EventTrigger;


public class EnemyBaseScript : MonoBehaviour
{
    [field:SerializeField]public Rigidbody2D rigidbody { get; set; }
    public EnemyStateMachine stateMachine { get; set; }
    public IdleState idleState { get; set; }
    public PatrolState patrolState { get; set; }
    public ChasingPlayerState chasingPlayerState { get; set; }  
    [field: SerializeField] public BoxCollider2D WalkIntoWallCheck {  get; set; }
    [field: SerializeField] public Boolean WalkingIntoWall {  get; set; }
    [field: SerializeField] public LayerMask FloorMask { get; set; }
    [field: SerializeField] public int isFacingRight { get; set; } 
    public float Transformx { get; set; }
    public float maxSpeed { get; set; } = 5f;
    [field: SerializeField] public Boolean isChasingPlayer {  get; set; }
    public Animator animator;
    public Health_System health { get; set; }
    public bool isDebug;

    
    void Awake()
    {
        health = new Health_System(100, 100);
        stateMachine = new EnemyStateMachine();
        idleState = new IdleState(this, stateMachine);
        patrolState = new PatrolState(this, stateMachine);
        chasingPlayerState = new ChasingPlayerState(this, stateMachine);
        Transformx = transform.localScale.x;
        isFacingRight = 0;
        
    }

    void Start()
    {
        stateMachine.Initialize(idleState);
        FaceDirection();
    }

    void Update()
    {
        stateMachine.enemyState.FrameUpdate();
        FaceDirection();
        OnDeath();
        DebugCommand();
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

    public void OnDeath()
    {
        if(health.currentHealth <= 0)
        {
            animator.SetBool("isDead", true);
        }
    }
    public void DestroyGameObject()
    {
        Destroy(this.gameObject);
    }
    
    public void DebugCommand()
    {
        if(!isDebug)
        {
            return;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            health.TakeDamage(9999);
        }
    }
}
