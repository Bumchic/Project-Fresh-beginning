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
    //State Variable
    public PlayerStateMachine playerStateMachine { get; set; }
    public PlayerRunningState runningState { get; set; }
    public PlayerCrouchingState crouchingState { get; set; }
    public PlayerIdleState idleState { get; set; }
    public PlayerCrouchWalkingState CrouchWalkingState { get; set; }

    private void Awake()
    {
        playerStateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, playerStateMachine);
        runningState = new PlayerRunningState(this, playerStateMachine);
        crouchingState = new PlayerCrouchingState(this, playerStateMachine);
        CrouchWalkingState = new PlayerCrouchWalkingState(this, playerStateMachine);

    }

    void Start()
    {

        Transformx = transform.localScale.x;

        playerStateMachine.intizialize(idleState);
    }
    private void Update()
    {
        GetInput();
        playerStateMachine.CurrentPlayerState.FrameUpdate();
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

    private void AnimationTriggerEvent(AnimationTriggerType triggertype)
    {
       playerStateMachine.CurrentPlayerState.AnimationTriggerEvent(triggertype);
    }
    public enum AnimationTriggerType
    {
        Idle,
        Running,
        Crouching,
        CrouchWalking
    }
}


