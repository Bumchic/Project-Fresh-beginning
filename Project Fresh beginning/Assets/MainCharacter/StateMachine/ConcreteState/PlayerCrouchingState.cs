using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchingState : PlayerState
{
    public PlayerCrouchingState(Player player, PlayerStateMachine playerstatemachine) : base(player, playerstatemachine)
    {

    }

    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
    }

    public override void EnterState()
    {
        base.EnterState();
        player.animator.SetBool("IsCrouching", true);
    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("IsCrouching", false);
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(Mathf.Abs(player.xinput) > 0)
        {
            player.playerStateMachine.ChangeState(player.CrouchWalkingState);
        }

        if(Input.GetKeyDown(KeyCode.S))
        {
            player.playerStateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
