using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerState
{
    private float jumpPower = 5f;
    public PlayerJumpingState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }
    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
    }

    public override void EnterState()
    {
        base.EnterState();
        player.animator.SetBool("IsJumping",true);
    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("IsJumping", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        JumpMovement();
        if (Mathf.Abs(player.yinput) == 0 && player.grounded)
        {
            player.playerStateMachine.ChangeState(player.idleState);
        }

    }
    private void JumpMovement()
    {
        player.Rigidbody2d.velocity = new Vector2(player.Rigidbody2d.velocity.x, jumpPower);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
