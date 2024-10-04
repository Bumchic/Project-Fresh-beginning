using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Windows;
using UnityEngine.UIElements;

public class PlayerRunningState : PlayerState
{
    private float RunSpeed = 10f;
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
        if(Mathf.Abs(player.xinput) > 0)
        {
            player.WalkMovement(RunSpeed);
        }        
        if(Mathf.Abs(player.xinput) == 0)
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
