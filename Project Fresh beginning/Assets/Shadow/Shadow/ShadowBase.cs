

using System;
using UnityEngine;



public class ShadowBase :MonoBehaviour, IShadowMoveable
{
    [field: SerializeField] public float MoveSpeed { get; set; }
    [field:SerializeField]public Rigidbody2D rigidbody2D { get; set; }

    [field: SerializeField] public float FrictionPercent { get; set; }

    public Boolean InZoneFar { get; set; }
    public Boolean InZoneMiddle { get; set; }
    public Boolean InZoneClose { get; set; }
    
    public ShadowStateMachine stateMachine { get; set; }
    public ZoneCloseState zoneCloseState { get; set; }
    public ZoneMiddleState zoneMiddleState { get; set; }
    public ZoneFarState zoneFarState { get; set; }

  


    void Awake()
    {
        MoveSpeed = 50f;
        FrictionPercent = 0.95f;
        stateMachine = new ShadowStateMachine();
        zoneCloseState = new ZoneCloseState(this, stateMachine);
        zoneMiddleState = new ZoneMiddleState(this, stateMachine);
        zoneFarState = new ZoneFarState(this, stateMachine);
    }

    void Start()
    {
        stateMachine.initialize(zoneFarState);
       
        
    }
    void Update()
    {
        stateMachine.CurrentState.UpdateFrame();
    }

    void FixedUpdate()
    {
        stateMachine.CurrentState.FixedUpdateFrame();
        Friction(FrictionPercent);
    }
    public void Move(float Speed)
    {
            rigidbody2D.AddForce(new Vector2(Speed, rigidbody2D.velocity.y) * rigidbody2D.mass); 
    }
    public void MoveDebug(float Speed)
    {
        rigidbody2D.velocity = new Vector2(Speed, rigidbody2D.velocity.y);
    }

    public void Friction(float friction)
    {
        rigidbody2D.velocity = new Vector2(rigidbody2D.velocity.x * friction, rigidbody2D.velocity.y);
    }


   


}
