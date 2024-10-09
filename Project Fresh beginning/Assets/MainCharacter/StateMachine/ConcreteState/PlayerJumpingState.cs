using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpingState : PlayerState
{
    private float jumpPower = 10f;
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
        Debug.Log("jumping");
    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("IsJumping", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (Mathf.Abs(player.yinput) > 0 && player.grounded == true)
        {
            JumpMovement(jumpPower);
        }          

        if (Mathf.Abs(player.xinput) > 0)
        {
            player.WalkMovement(player.RunSpeed);
        }
/////////
        if (Mathf.Abs(player.yinput) == 0 && player.grounded)
        {
            player.WalkMovement(0);
            player.playerStateMachine.ChangeState(player.idleState);
        }

        if(Mathf.Abs(player.yinput) == 0)
        {
            JumpMovement(0);
            player.WalkMovement(0);
            player.playerStateMachine.ChangeState(player.fallingState);
        }
        if (player.Rigidbody2d.velocity.y < 0)
        {
            player.playerStateMachine.ChangeState(player.fallingState);
        }

    }
    private void JumpMovement(float jumpPower)
    {       
        player.Rigidbody2d.velocity = new Vector2(player.Rigidbody2d.velocity.x, jumpPower);
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
