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
        
    }

    public override void ExitState()
    {
        base.ExitState();
    }

    public override void FrameUpdate()
    {
        base.FrameUpdate();
        if(Mathf.Abs(player.xinput) > 0)
        {
           player.playerStateMachine.ChangeState(player.runningState);
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            player.playerStateMachine.ChangeState(player.crouchingState);
        }
        }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
}
