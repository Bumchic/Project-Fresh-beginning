

using System;
using UnityEngine;



public class ShadowBase :MonoBehaviour, IShadowMoveable
{
    [field: SerializeField] public float MoveSpeed { get; set; }
    [field:SerializeField]public Rigidbody2D rigidbody2D { get; set; }

    public Boolean InZoneFar { get; set; }
    public Boolean InZoneMiddle { get; set; }
    public Boolean InZoneClose { get; set; }
    
    public ShadowStateMachine stateMachine { get; set; }
    public ZoneCloseState zoneCloseState { get; set; }
    public ZoneMiddleState zoneMiddleState { get; set; }
    public ZoneFarState zoneFarState { get; set; }


    void Awake()
    {
        stateMachine = new ShadowStateMachine();
        zoneCloseState = new ZoneCloseState(this, stateMachine);
        zoneMiddleState = new ZoneMiddleState(this, stateMachine);
        zoneFarState = new ZoneFarState(this, stateMachine);
    }

    void Start()
    {
        stateMachine.intialize(zoneFarState);
        MoveSpeed = 10f;
        
    }
    void Update()
    {
        stateMachine.CurrentState.UpdateFrame();
    }

    void FixedUpdate()
    {
        stateMachine.CurrentState.FixedUpdateFrame();  
    }
    public void Move(float Speed)
    {
            rigidbody2D.AddForce(new Vector2(Speed, rigidbody2D.velocity.y) * rigidbody2D.mass); 
    }

   


}
