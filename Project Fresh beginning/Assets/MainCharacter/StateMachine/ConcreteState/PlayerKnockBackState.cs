using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockBackState : PlayerState
{
    private Rigidbody2D rigidbody;
    public PlayerKnockBackState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine) { }
    public override void EnterState()
    {
        rigidbody.velocity = new Vector2(-5f, rigidbody.velocity.y);
    }


    public override void ExitState(){}
    public override void FrameUpdate() { }
    public override void PhysicUpdate() { }

}
