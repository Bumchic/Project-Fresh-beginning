using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.UIElements;

public class PlayerRunningState : PlayerState
{

    public PlayerRunningState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }
    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
    }

    public override void EnterState()
    {
        base.EnterState();
        player.animator.SetBool("IsRunning", true);

    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("IsRunning", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (Mathf.Abs(player.xinput) > 0)
        {
            player.WalkMovement(player.RunSpeed);
        }
        if (Mathf.Abs(player.xinput) == 0)
        {
            player.WalkMovement(0);
            player.playerStateMachine.ChangeState(player.idleState);
        }

        if (player.yinput > 0 && player.grounded == true )
        {
            player.playerStateMachine.ChangeState(player.jumpingState);
        }
        if(player.Rigidbody2d.velocity.y < 0 && player.grounded == false)
        {
            player.playerStateMachine.ChangeState(player.fallingState);
        }
        if(Input.GetKeyDown(KeyCode.S))
        {
            player.playerStateMachine.ChangeState(player.crouchingState);
        }
        if(Input.GetKeyDown(KeyCode.J))
        {
            player.playerStateMachine.ChangeState(player.normalPunchState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }


}