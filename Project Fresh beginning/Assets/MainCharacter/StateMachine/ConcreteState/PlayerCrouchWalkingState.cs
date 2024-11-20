using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchWalkingState : PlayerState
{
    private float CrouchSpeed = 3f;
    public PlayerCrouchWalkingState(Player player, PlayerStateMachine playerstatemachine) : base(player, playerstatemachine)
    {

    }
    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
    }

    public override void EnterState()
    {
        base.EnterState();
        player.animator.SetBool("IsCrouchWalking", true);
    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("IsCrouchWalking", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if (Mathf.Abs(player.xinput) > 0)
        {
            player.WalkMovement(CrouchSpeed);
        }
        if (Mathf.Abs(player.xinput) == 0)
        {
            player.WalkMovement(0);
            player.playerStateMachine.ChangeState(player.crouchingState);
        }
        if (player.Rigidbody2d.velocity.y < 0)
        {
            player.playerStateMachine.ChangeState(player.fallingState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
