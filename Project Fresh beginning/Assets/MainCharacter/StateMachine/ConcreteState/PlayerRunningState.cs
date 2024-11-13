using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Windows;
using UnityEngine.UIElements;

public class PlayerRunningState : PlayerState
{
    private bool isSpeedBoosted = false; //
    private float speedBoostMultiplier = 1.5f; //
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
        float currentSpeed = isSpeedBoosted ? player.RunSpeed * speedBoostMultiplier : player.RunSpeed;//
        if (Mathf.Abs(player.xinput) > 0)
        {
            player.WalkMovement(player.RunSpeed);
        }        
        if(Mathf.Abs(player.xinput) == 0)
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
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }
   
    public void ActivateSpeedBoost()//
    {
        isSpeedBoosted = true;
    }

   
    public void DeactivateSpeedBoost()//
    {
        isSpeedBoosted = false;
    }

}
