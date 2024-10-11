using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IMoveable

{

    public Animator animator;
    [field: SerializeField] public Rigidbody2D Rigidbody2d { get; set; }
    public float xinput { get; set; }
    public float yinput { get; set; }
    public float Transformx {get; set;}
    [field: SerializeField] public BoxCollider2D FloorCheck { get; set;}
    [field: SerializeField] public LayerMask FloorCheckMask { get; set; }
    public Boolean grounded;
    public float RunSpeed { get; set; }
    [field: SerializeField] public BoxCollider2D ColliderStandUpCheck { get; set; }
    [field: SerializeField] public LayerMask HeadCollisionMask { get; set; }
    public bool HeadCollision;

    [field: SerializeField] public BoxCollider2D Collider { get; set; }
    //State Variable
    public PlayerStateMachine playerStateMachine { get; set; }
    public PlayerRunningState runningState { get; set; }
    public PlayerCrouchingState crouchingState { get; set; }
    public PlayerIdleState idleState { get; set; }
    public PlayerCrouchWalkingState CrouchWalkingState { get; set; }
    public PlayerJumpingState jumpingState { get; set; }
    public PlayerFallingState fallingState { get; set; }
 

    private void Awake()
    {
        playerStateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, playerStateMachine);
        runningState = new PlayerRunningState(this, playerStateMachine);
        crouchingState = new PlayerCrouchingState(this, playerStateMachine);
        CrouchWalkingState = new PlayerCrouchWalkingState(this, playerStateMachine);
        jumpingState = new PlayerJumpingState(this, playerStateMachine);
        fallingState = new PlayerFallingState(this, playerStateMachine);

    }

    void Start()
    {
        RunSpeed = 10f;
        Transformx = transform.localScale.x;

        playerStateMachine.intizialize(idleState);
    }
    private void Update()
    {
        HeadCollisionCheck();
        Groundcheck();
        gameOver();
        GetInput();
        playerStateMachine.CurrentPlayerState.FrameUpdate();
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Shadow")
        {
            PlayerTakeDamage(9999);
        }
        
    }
    private void FixedUpdate()
    {
        playerStateMachine.CurrentPlayerState.PhysicUpdate();
    }

    public void Die()
    {
        GameOver.LoadMainMenu();
    }



    public void GetInput()
    {
        xinput = Input.GetAxis("Horizontal");
        yinput = Input.GetAxis("Vertical");
    }

    public void WalkMovement(float speed)
    {
        
            Rigidbody2d.velocity = new Vector2(speed * Mathf.Sign(xinput), Rigidbody2d.velocity.y);
            FaceDirection();
 
        
    }
    public void FaceDirection()
    {
        if(Mathf.Abs(xinput) != 0)
        {
            float Direction = Mathf.Sign(xinput);
            transform.localScale = new Vector3(Direction * Transformx, transform.localScale.y, transform.localScale.z);
        }
        
    }
    void Groundcheck()
    {      
        grounded = Physics2D.OverlapAreaAll(FloorCheck.bounds.min, FloorCheck.bounds.max, FloorCheckMask).Length > 0;
    }


    void HeadCollisionCheck()
    {
        HeadCollision = Physics2D.OverlapAreaAll(ColliderStandUpCheck.bounds.min, ColliderStandUpCheck.bounds.max, HeadCollisionMask).Length > 0;
    }
    //Health
    private void gameOver()
    {
        if (GameManager.gameManager.PlayerHealth.currentHealth <= 0)
        {
            GameOver.LoadMainMenu();
        }
    }
    private void PlayerTakeDamage(int DamageAmount)
    {
        GameManager.gameManager.PlayerHealth.TakeDamage(DamageAmount);
    }

    private void PlayerHeal(int HealAmount)
    {
        GameManager.gameManager.PlayerHealth.Heal(HealAmount);
    }


    //The event in animation window will call this function
    private void AnimationTriggerEvent(AnimationTriggerType triggertype)
    {
       playerStateMachine.CurrentPlayerState.AnimationTriggerEvent(triggertype);
    }



    public enum AnimationTriggerType
    {
        
    }
}


