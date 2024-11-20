using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallingState : PlayerState
{
    public PlayerFallingState(Player player, PlayerStateMachine playerStateMachine) : base(player, playerStateMachine)
    {

    }
    public override void AnimationTriggerEvent(Player.AnimationTriggerType triggertype)
    {
        base.AnimationTriggerEvent(triggertype);
    }

    public override void EnterState()
    {
        base.EnterState();
        player.animator.SetBool("IsFalling", true);
        Debug.Log("fallings");
    }

    public override void ExitState()
    {
        base.ExitState();
        player.animator.SetBool("IsFalling", false);
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
        }

        if (player.grounded == true)
        {
            player.WalkMovement(0);
            player.playerStateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
