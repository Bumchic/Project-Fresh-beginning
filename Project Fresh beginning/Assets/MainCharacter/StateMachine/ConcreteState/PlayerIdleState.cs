using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }
    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
    }

    public override void EnterState()
    {
        base.EnterState();
        player.Rigidbody2d.gravityScale = player.GravScale;
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        //Change State
        if(Mathf.Abs(player.xinput) > 0)
        {
           player.playerStateMachine.ChangeState(player.runningState);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.playerStateMachine.ChangeState(player.crouchingState);
        }

        if(player.yinput > 0 && player.grounded == true)
        {
            player.playerStateMachine.ChangeState(player.jumpingState);
        }
        if (player.Rigidbody2d.velocity.y < 0 && player.grounded == false)
        {
            player.playerStateMachine.ChangeState(player.fallingState);
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            player.Combo = 1;
            player.playerStateMachine.ChangeState(player.normalPunchState);
        }
    }
    

public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
