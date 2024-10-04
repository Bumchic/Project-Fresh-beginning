using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamagable, IMoveable

{
    [field: SerializeField] public float CurrentHealth { get; set; } = 100f;
    public float MaxHealth { get; set; }
    [field: SerializeField] public Rigidbody2D Rigidbody2d { get; set; }
    public float xinput { get; set; }
    public float yinput { get; set; }

    public float Transformx {get; set;}

    public PlayerStateMachine playerStateMachine { get; set; }
    public PlayerRunningState runningState { get; set; }
    public PlayerCrouchingState crouchingState { get; set; }
    public PlayerIdleState idleState { get; set; }

    private void Awake()
    {
        playerStateMachine = new PlayerStateMachine();
        idleState = new PlayerIdleState(this, playerStateMachine);
        runningState = new PlayerRunningState(this, playerStateMachine);
        crouchingState = new PlayerCrouchingState(this, playerStateMachine);

    }

    void Start()
    {
        CurrentHealth = MaxHealth;
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

    public void Heal(float HealAmount)
    {
        CurrentHealth += HealAmount;
        if(CurrentHealth > MaxHealth)
        {
            CurrentHealth = MaxHealth;
        }
    }

    public void TakeDamage(float Damage)
    {
       if(CurrentHealth > 0)
        {
            CurrentHealth -= Damage;
        }
    }

    public void GetInput()
    {
        xinput = Input.GetAxis("Horizontal");
        yinput = Input.GetAxis("Vertical");
    }

    
    private void AnimationTriggerEvent(AnimationTriggerType triggertype)
    {
       playerStateMachine.CurrentPlayerState.AnimationTriggerEvent(triggertype);
    }
    public enum AnimationTriggerType
    {
        Idle,
        Running,
        Crouching
    }
}


