using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;
using UnityEngine.Windows;
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
        Debug.Log("Running");
        
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
            WalkMovement();
        }           
        if(Mathf.Abs(player.xinput) == 0)
        {
            player.playerStateMachine.ChangeState(player.idleState);
        }
    }

    public override void PhysicUpdate()
    {
        base.PhysicUpdate();
    }

    public void WalkMovement()
    {      
            player.Rigidbody2d.velocity = new Vector2(player.xinput, player.Rigidbody2d.velocity.y);
            FaceDirection();
    }
    public void FaceDirection()
    {
        float Direction = Mathf.Sign(player.xinput);
        player.transform.localScale = new Vector3(Direction * player.Transformx, player.transform.localScale.y, player.transform.localScale.z);
    }
}
